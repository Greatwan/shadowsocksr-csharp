using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Shadowsocks.Controller;
using Shadowsocks.Model;
using Shadowsocks.Properties;
using Shadowsocks.Util;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Shadowsocks.View
{
    public partial class ApiForm : Form
    {
        private ShadowsocksController controller;
        // this is a copy of configuration that we are working on
        private Configuration _modifiedConfiguration;

        private BackgroundWorker backgroundWorker;

        private NewMainForm newMainForm;

        private UpdateSubscribeManager updateSubscribeManager;

        private int userIndex = 0;

        public ApiForm(ShadowsocksController controller)
        {
            this.Font = System.Drawing.SystemFonts.MessageBoxFont;
            InitializeComponent();
            this.Icon = Icon.FromHandle(Resources.ssw128.GetHicon());
            this.controller = controller;
            LoadCurrentConfiguration();
            UpdateTexts();

            updateSubscribeManager = new UpdateSubscribeManager();

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            //backgroundWorker.CancelAsync();
            
        }



        private void LoadCurrentConfiguration()
        {
            _modifiedConfiguration = controller.GetConfiguration();
        }

        private void UpdateTexts()
        {
            //Configuration config = controller.GetCurrentConfiguration();
            this.Text = I18N.GetString("ApiForm");
            labelEmail.Text = I18N.GetString("Api_Email");
            labelPass.Text = I18N.GetString("Api_Password");
            buttonSave.Text = I18N.GetString("Save");
            buttonCancel.Text = I18N.GetString("Cancel");

            if (_modifiedConfiguration.userInfos.Count > 0) {
                for (int i = 0; i < _modifiedConfiguration.userInfos.Count; i++)
                {
                    if (_modifiedConfiguration.userInfos[i].userEmail.Contains("@"))
                    {
                        textBoxEmail.Text = _modifiedConfiguration.userInfos[i].userEmail;
                        break;
                    }
                }
            }
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void saveConfig()
        {
            UserInfo userinfo = new UserInfo();
            userinfo.userEmail = textBoxEmail.Text;
            if (_modifiedConfiguration.userInfos.Count == 0)
            {
                _modifiedConfiguration.userInfos.Add(userinfo);
            } else {
                for (int i = 0; i < _modifiedConfiguration.userInfos.Count; i++)
                {
                    if (_modifiedConfiguration.userInfos[i].userEmail == userinfo.userEmail)
                    {
                        userIndex = i;
                        _modifiedConfiguration.userInfos[i] = userinfo;
                        Console.WriteLine("edit UserInfo");
                        //Configuration.Save(config);
                        break;
                        //SaveConfig(_config);
                    }
                }
            }

            controller.SaveServersConfig(_modifiedConfiguration);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveConfig();
            buttonSave.Enabled = false;
            buttonCancel.Enabled = false;
            textBoxEmail.ReadOnly = true;
            textBoxPass.ReadOnly = true;
            progressBarLogin.Visible = true;
            buttonProgressCancel.Visible = true;
            backgroundWorker.RunWorkerAsync();
            //this.Close();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // update view
            progressBarLogin.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
            }
            else
            {
                // Perform a time consuming operation and report progress.
                Console.WriteLine("get token");
                JObject jo = Login.GetToken(textBoxEmail.Text, textBoxPass.Text);
                if (jo != null)
                {
                    if (jo["data"].ToString() != "")
                    {
                        //Console.WriteLine("token: "+jo["data"].ToString());
                        _modifiedConfiguration.userInfos[userIndex].userToken = jo["data"].ToString();
                        controller.SaveServersConfig(_modifiedConfiguration);


                        //Console.WriteLine(jo["data"].ToString());
                        //System.Threading.Thread.Sleep(500);
                        worker.ReportProgress(50);
                        JObject userInfoJO = Login.GetLoginJObject(controller, userIndex);
                        Console.WriteLine("get userInfo");
                        if (userInfoJO != null)
                        {
                            _modifiedConfiguration.userInfos[userIndex].userName = userInfoJO["data"]["userName"].ToString();
                            _modifiedConfiguration.userInfos[userIndex].userMoney = userInfoJO["data"]["userMoney"].ToString();
                            _modifiedConfiguration.userInfos[userIndex].apiReserveUrl = userInfoJO["data"]["apiReserveUrl"].ToString();
                            controller.SaveServersConfig(_modifiedConfiguration);

                            worker.ReportProgress(75);
                            // @TODO
                            // update server
                            //Console.WriteLine("update server:"+ userInfoJO["data"]["ssr_url_all"].ToString());
                            int count = Utils.updateServerFromSSRURL(controller, updateSubscribeManager, Util.Base64.DecodeUrlSafeBase64(userInfoJO["data"]["ssr_url_all"].ToString()));

                            worker.ReportProgress(80);
                        } else
                        {
                            Console.WriteLine("userInfoJO == null");
                        }

                    } else
                    {
                        Console.WriteLine("no_token->jo[\"data\"].ToString() == \"\"");
                        e.Cancel = true;
                    }

                } else
                {
                    Console.WriteLine("jotoken == null");
                }

            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonSave.Enabled = true;
            buttonCancel.Enabled = true;
            textBoxEmail.ReadOnly = false;
            textBoxPass.ReadOnly = false;
            buttonProgressCancel.Visible = false;
            Console.WriteLine("finished");
            
            // @TODO 
            // 成功后，2秒后关闭界面
            ShowNewMainForm();
            this.Close();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                textBoxPass.PasswordChar = '\0';
            }
            else
            {
                textBoxPass.PasswordChar = '*';
            }
        }

        private void buttonProgressCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            buttonProgressCancel.Visible = false;
        }
        private void ShowNewMainForm()
        {
            if (newMainForm != null)
            {
                newMainForm.Activate();
                newMainForm.Update();
                if (newMainForm.WindowState == FormWindowState.Minimized)
                {
                    newMainForm.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                newMainForm = new NewMainForm(controller);
                newMainForm.Show();
                newMainForm.Activate();
                newMainForm.BringToFront();
                newMainForm.FormClosed += newMainForm_FormClosed;
            }
        }
        void newMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            newMainForm = null;
        }

    }
}
