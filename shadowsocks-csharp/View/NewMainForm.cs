using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using Shadowsocks.Controller;
using Shadowsocks.Model;
using Shadowsocks.Util;
using Shadowsocks.Properties;
//using Shadowsocks.Util

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Shadowsocks.View
{
    public partial class NewMainForm : Form
    {
        private ShadowsocksController controller;
        // this is a copy of configuration that we are working on
        private Configuration _modifiedConfiguration;
        private ServerLogForm serverLogForm;
        private NotifyIcon _notifyIcon;
        private UpdateFreeNode updateFreeNodeChecker;
        private UpdateSubscribeManager updateSubscribeManager;
        private ConfigForm configForm;
        private AccountForm accountForm;
        private SubscribeForm subScribeForm;
        private LogForm logForm;
        private UpdateChecker updateChecker;
        public delegate void treeinvoke();
        private ServerSpeedLogShow[] ServerSpeedLogList;
        private AutoResetEvent workerEvent = new AutoResetEvent(false);
        private Thread workerThread;
        private int updatePause = 0;
        private int updateTick = 0;
        private int updateSize = 0;
        private int pendingUpdate = 0;

        public NewMainForm(ShadowsocksController controller)
        {
            this.Font = System.Drawing.SystemFonts.MessageBoxFont;
            InitializeComponent();
            this.Icon = Icon.FromHandle(Resources.ssw128.GetHicon());
            this.controller = controller;
            LoadCurrentConfiguration();
            UpdateTexts();
            LoadServer();
            updateChecker = new UpdateChecker();
            //Thread t = new Thread(new ThreadStart(show_ping_start));
            //t.Start();
            controller.ConfigChanged += controller_ConfigChanged;

            updateFreeNodeChecker = new UpdateFreeNode();
            updateFreeNodeChecker.NewFreeNodeFound += updateFreeNodeChecker_NewFreeNodeFound;
            updateSubscribeManager = new UpdateSubscribeManager();
            _notifyIcon = new NotifyIcon();
        }

        private void comboBoxConnectType_selectIndexChangedEvent(object sender, EventArgs e)
        {
            switch (comboBoxConnectType.SelectedIndex)
            {
                case 0:
                    buttonConnect.Text = I18N.GetString("Click To Start");
                    controller.ToggleMode(ProxyMode.Direct);
                    break;
                case 1:
                    buttonConnect.Text = I18N.GetString("Click To Stop");
                    controller.ToggleMode(ProxyMode.Pac);
                    break;
                case 2:
                    buttonConnect.Text = I18N.GetString("Click To Stop");
                    controller.ToggleMode(ProxyMode.Global);
                    break;
            }

        }

        private void LoadCurrentConfiguration()
        {
            _modifiedConfiguration = controller.GetConfiguration();
        }

        private void UpdateTexts()
        {
            Configuration c = controller.GetConfiguration();
            if (c.userInfos.Count>0)
            {
                labelTrafficRemainValue.Text = c.userInfos[0].traffic_remain;
                labelDueDateValue.Text = c.userInfos[0].expire_time;
            }
            //Configuration config = controller.GetCurrentConfiguration();
            this.Text = I18N.GetString("NewMainForm");
            labelConnectType.Text = I18N.GetString("Connect_type");
            labelDueDate.Text = I18N.GetString("Class_expire");
            labelTrafficRemain.Text = I18N.GetString("unusedTraffic");
            labelSpeedDl.Text = I18N.GetString("DL");
            labelSpeedUp.Text = I18N.GetString("UP");

            labelSocksPort.Text = "socks"+I18N.GetString("Port");
            buttonSocksPortAction.Text = I18N.GetString("Edit");
            numericUpDownSocksPort.Value = _modifiedConfiguration.localPort;

            buttonConnect.Text = I18N.GetString("Connect");

            subscribeToolStripMenuItem.Text = I18N.GetString("Subscribe");

            helpToolStripMenuItem.Text = I18N.GetString("Help");
            logToolStripMenuItem.Text = I18N.GetString("Log");
            statisticToolStripMenuItem.Text = I18N.GetString("Statistics");
            contactToolStripMenuItem.Text = I18N.GetString("Contact");

            testToolStripMenuItem.Text = I18N.GetString("Test");
            testAllToolStripMenuItem.Text = I18N.GetString("testAll");

            updateToolStripMenuItem.Text = I18N.GetString("Update");
            updateFromAccountToolStripMenuItem.Text = I18N.GetString("updateFromAccount");
            updateFromSubscribeToolStripMenuItem.Text = I18N.GetString("updateFromSubscribe");
            updateAllToolStripMenuItem.Text = I18N.GetString("updateAll");

            serverToolStripMenuItem.Text = I18N.GetString("ServerManage");
            serverEditToolStripMenuItem.Text = I18N.GetString("ServerEdit");

            serverImportToolStripMenuItem.Text = I18N.GetString("ServerImport");
            serverImportFromClipboardToolStripMenuItem.Text = I18N.GetString("ServerImportFromClipboard");
            serverImportFromQrcodeToolStripMenuItem.Text = I18N.GetString("ServerImportFromQrcode");
            serverImportManuallySetupToolStripMenuItem.Text = I18N.GetString("ServerImportManuallySetup");
        }
        
        private void LoadServer()
        {
            //if ()

            //if (label7.Text.Contains("Lv"))
            //{
            //    JObject jo = Login.GetLoginJObject();

            //    if (jo != null)
            //    {
            //        label7.Text = "Lv " + jo["data"]["class"].ToString();
            //        label5.Text = jo["data"]["unusedTraffic"].ToString();
            //        label3.Text = jo["data"]["class_expire"].ToString();
            //    }
            //}
            
            Configuration c = controller.GetConfiguration();

            // 第一次启动时，listView1.Items.Count 会从0逐步增加

            if (listViewServerBox.Items.Count > 0)
            {
                if (this.IsHandleCreated)
                {
                    // MessageBox.Show("this.IsHandleCreated");
                    listViewServerBox.BeginInvoke(new treeinvoke(() =>
                    {
                        listViewServerBox.Items.Clear();
                        LoadServerStep2();
                    }));
                }
                else
                {
                    // MessageBox.Show("not this.IsHandleCreated");
                    listViewServerBox.Items.Clear();
                    LoadServerStep2();
                }
            }
            else
            {
                LoadServerStep2();
            }

        }

        private void LoadServerStep2()
        {
            Configuration c = controller.GetConfiguration();
            //ServerSpeedLogShow serverSpeedLog = ServerSpeedLogList[c.index];
            for (int i = 0; i < c.configs.Count; i++)
            {
                Server s = c.configs[i];
                string[] item = { s.FriendlyName(), "", "" };
                ListViewItem itm = new ListViewItem(item);
                //itm.BackColor = Color.Silver;
                //itm.ForeColor = Color.White;
                //itm.
                if (c.index == i)
                {
                    itm.BackColor = Color.FromArgb(10, 36, 106);
                    itm.ForeColor = Color.White;
                }
                listViewServerBox.Items.Add(itm);
            }
            switch (c.sysProxyMode)
            {
                case 1:
                    comboBoxConnectType.SelectedIndex = 0;
                    buttonConnect.Text = I18N.GetString("Click To Start");
                    break;
                case 2:
                    comboBoxConnectType.SelectedIndex = 1;
                    buttonConnect.Text = I18N.GetString("Click To Stop");
                    break;
                case 3:
                    comboBoxConnectType.SelectedIndex = 2;
                    buttonConnect.Text = I18N.GetString("Click To Stop");
                    break;
            }
        }

        private void controller_ConfigChanged(object sender, EventArgs e)
        {
            LoadServer();
        }

        private void DisconnectCurrent(object sender, EventArgs e)
        {
            Configuration config = controller.GetCurrentConfiguration();
            for (int id = 0; id < config.configs.Count; ++id)
            {
                Server server = config.configs[id];
                server.GetConnections().CloseAll();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("hi");
            if (listViewServerBox.SelectedItems.Count == 0)
            {
                return;
            }
            else if (listViewServerBox.SelectedItems.Count == 1)
            {
                //MessageBox.Show(Convert.ToString(listView1.SelectedItems.Count));
                //_modifiedConfiguration.index = listView1.SelectedItems[0].Index;
                //_modifiedConfiguration
                
                //int this_index = listView1.SelectedItems[0].Index;
                
                //controller.SelectServerIndex(this_index);
                //listView1.Items[this_index].BackColor = Color.Silver;
                //DisconnectCurrent(this, new EventArgs());
            }
            
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listViewServerBox.SelectedItems.Count == 0)
            {
                return;
            }
            else if (listViewServerBox.SelectedItems.Count == 1)
            {
                //MessageBox.Show(Convert.ToString(listView1.SelectedItems.Count));
                //_modifiedConfiguration.index = listView1.SelectedItems[0].Index;
                //_modifiedConfiguration

                int last_index = controller.GetConfiguration().index;
                int this_index = listViewServerBox.SelectedItems[0].Index;

                listViewServerBox.Items[last_index].BackColor = Color.White;
                listViewServerBox.Items[last_index].ForeColor = Color.Black;
                controller.SelectServerIndex(this_index);
                listViewServerBox.Items[this_index].BackColor = Color.FromArgb(10, 36, 106);
                listViewServerBox.Items[this_index].ForeColor = Color.White;
                DisconnectCurrent(this, new EventArgs());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configuration c = controller.GetConfiguration();
            
            if (listViewServerBox.SelectedItems.Count>0)
            {
                int last_index = controller.GetConfiguration().index;
                int this_index = listViewServerBox.SelectedItems[0].Index;

                if (last_index != this_index)
                {
                    listViewServerBox.Items[last_index].BackColor = Color.White;
                    listViewServerBox.Items[last_index].ForeColor = Color.Black;
                    controller.SelectServerIndex(this_index);
                    listViewServerBox.Items[this_index].BackColor = Color.FromArgb(10, 36, 106);
                    listViewServerBox.Items[this_index].ForeColor = Color.White;
                    DisconnectCurrent(this, new EventArgs());
                }
            }
            if (comboBoxConnectType.SelectedIndex != c.sysProxyMode - 1)
            {
                comboBoxConnectType.SelectedIndex = c.sysProxyMode - 1;
            }
            else
            {
                // 同一模式，点击该按钮
                switch (comboBoxConnectType.SelectedIndex)
                {
                    case 0:
                        comboBoxConnectType.SelectedIndex = 1;
                        break;
                    case 1:
                        comboBoxConnectType.SelectedIndex = 0;
                        break;
                    case 2:
                        comboBoxConnectType.SelectedIndex = 0;
                        break;
                }
            }
        }

        private void show_ping()
        {
            
            Configuration c = controller.GetConfiguration();
            for (int i = 0; i < listViewServerBox.Items.Count; i++)
            {
                //Console.WriteLine("1: " + Convert.ToString(i));
                string ip = c.configs[i].server;
                int port = c.configs[i].server_port;

                my_param m = new my_param();
                m.i = i;
                m.ip = ip;
                m.method = 0;
                Thread t = new Thread(new ParameterizedThreadStart(inthread));
                t.Start(m);

                my_param mm = new my_param();
                mm.i = i;
                mm.ip = ip;
                mm.port = port;
                mm.method = 1;
                Thread tt = new Thread(new ParameterizedThreadStart(inthread));
                tt.Start(mm);
            }
        }

        private void inthread(object obj)
        {
            my_param o = (my_param)obj;
            if (o.method == 0)
            {
                string ip = Utils.getIp(o.ip);
                if ( ip == "no ip")
                {
                    string resp = "no ip";
                    if (this.IsHandleCreated)
                    {
                        listViewServerBox.BeginInvoke(new treeinvoke(() =>
                        {
                            listViewServerBox.Items[o.i].SubItems[1].Text = resp;
                        }));
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    string resp = Utils.ping_example_3(o.ip);
                    if (this.IsHandleCreated)
                    {
                        listViewServerBox.BeginInvoke(new treeinvoke(() =>
                        {
                            listViewServerBox.Items[o.i].SubItems[1].Text = resp;
                        }));
                    }
                    else
                    {
                        return;
                    }
                }
                


            }
            else if (o.method == 1)
            {
                string ip = Utils.getIp(o.ip);
                if (ip=="no ip")
                {
                    string resp = "no ip";
                    if (this.IsHandleCreated)
                    {
                        listViewServerBox.BeginInvoke(new treeinvoke(() =>
                        {
                            listViewServerBox.Items[o.i].SubItems[2].Text = resp;
                        }));
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    string resp = Utils.tcping_3(o.ip, o.port);
                    if (this.IsHandleCreated)
                    {
                        listViewServerBox.BeginInvoke(new treeinvoke(() =>
                        {
                            listViewServerBox.Items[o.i].SubItems[2].Text = resp;
                        }));
                    }
                    else
                    {
                        return;
                    }
                }
            }

        }

        void serverLogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            serverLogForm = null;
            Util.Utils.ReleaseMemory();
        }

        void configForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            configForm = null;
            Util.Utils.ReleaseMemory();
        }

        void accountForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            accountForm = null;
            Util.Utils.ReleaseMemory();
        }

        void globalLogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logForm = null;
            Util.Utils.ReleaseMemory();
        }

        void subScribeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            subScribeForm = null;
        }

        private void ShowServerLogForm()
        {
            if (serverLogForm != null)
            {
                serverLogForm.Activate();
                serverLogForm.Update();
                if (serverLogForm.WindowState == FormWindowState.Minimized)
                {
                    serverLogForm.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                serverLogForm = new ServerLogForm(controller);
                serverLogForm.Show();
                serverLogForm.Activate();
                serverLogForm.BringToFront();
                serverLogForm.FormClosed += serverLogForm_FormClosed;
            }
        }

        private void ShowConfigForm(bool addNode)
        {
            if (configForm != null)
            {
                configForm.Activate();
                // MessageBox.Show("1");
                if (addNode)
                {
                    Configuration cfg = controller.GetCurrentConfiguration();
                    configForm.SetServerListSelectedIndex(cfg.index + 1);
                }
            }
            else
            {
                //MessageBox.Show("2.0");
                configForm = new ConfigForm(controller, updateChecker, addNode ? -1 : -2);
                //MessageBox.Show("2.1");
                configForm.Show();
                //MessageBox.Show("2.2");
                configForm.Activate();
                configForm.BringToFront();
                configForm.FormClosed += configForm_FormClosed;
            }
        }

        private void ShowAccountForm()
        {
            if (accountForm != null)
            {
                accountForm.Activate();
                accountForm.Update();
                if (accountForm.WindowState == FormWindowState.Minimized)
                {
                    accountForm.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                accountForm = new AccountForm(controller);
                accountForm.Show();
                accountForm.Activate();
                accountForm.BringToFront();
                accountForm.FormClosed += accountForm_FormClosed;
            }
        }

        private void ShowGlobalLogForm()
        {
            if (logForm != null)
            {
                logForm.Activate();
                logForm.Update();
                if (logForm.WindowState == FormWindowState.Minimized)
                {
                    logForm.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                logForm = new LogForm(controller);
                logForm.Show();
                logForm.Activate();
                logForm.BringToFront();
                logForm.FormClosed += globalLogForm_FormClosed;
            }
        }

        private void ShowSubscribeSettingForm()
        {
            if (subScribeForm != null)
            {
                subScribeForm.Activate();
                subScribeForm.Update();
                if (subScribeForm.WindowState == FormWindowState.Minimized)
                {
                    subScribeForm.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                subScribeForm = new SubscribeForm(controller);
                subScribeForm.Show();
                subScribeForm.Activate();
                subScribeForm.BringToFront();
                subScribeForm.FormClosed += subScribeForm_FormClosed;
            }
        }

        private string FormatBytes(long bytes)
        {
            const long K = 1024L;
            const long M = K * 1024L;
            const long G = M * 1024L;
            const long T = G * 1024L;
            const long P = T * 1024L;
            const long E = P * 1024L;

            if (bytes >= M * 990)
            {
                if (bytes >= G * 990)
                {
                    if (bytes >= P * 990)
                        return (bytes / (double)E).ToString("F3") + "EB/s";
                    if (bytes >= T * 990)
                        return (bytes / (double)P).ToString("F3") + "PB/s";
                    return (bytes / (double)T).ToString("F3") + "TB/s";
                }
                else
                {
                    if (bytes >= G * 99)
                        return (bytes / (double)G).ToString("F2") + "GB/s";
                    if (bytes >= G * 9)
                        return (bytes / (double)G).ToString("F3") + "GB/s";
                    return (bytes / (double)G).ToString("F4") + "GB/s";
                }
            }
            else
            {
                if (bytes >= K * 990)
                {
                    if (bytes >= M * 100)
                        return (bytes / (double)M).ToString("F1") + "MB/s";
                    if (bytes > M * 9.9)
                        return (bytes / (double)M).ToString("F2") + "MB/s";
                    return (bytes / (double)M).ToString("F3") + "MB/s";
                }
                else
                {
                    if (bytes > K * 99)
                        return (bytes / (double)K).ToString("F0") + "KB/s";
                    if (bytes > 900)
                        return (bytes / (double)K).ToString("F1") + "KB/s";
                    return bytes.ToString() + "B/s";
                }
            }
        }
        
        public void UpdateLogThread()
        {
            while (workerThread != null)
            {
                Configuration config = controller.GetCurrentConfiguration();

                ServerSpeedLogShow[] _ServerSpeedLogList = new ServerSpeedLogShow[1];

                _ServerSpeedLogList[0] = config.configs[config.index].ServerSpeedLog().Translate();
                ServerSpeedLogList = _ServerSpeedLogList;
                //MessageBox.Show(FormatBytes(ServerSpeedLogList[0].avgDownloadBytes));
                workerEvent.WaitOne();
            }
        }

        public void RefreshLog()
        {
            //MessageBox.Show("RefreshLog");
            //if (ServerSpeedLogList == null)
            //{
            //    label9.Text = FormatBytes(ServerSpeedLogList[0].avgDownloadBytes);
            //    return;
            //}

            //MessageBox.Show(FormatBytes(ServerSpeedLogList[0].avgDownloadBytes) + " " + FormatBytes(ServerSpeedLogList[0].avgUploadBytes));
            labelSpeedDlValue.Text = FormatBytes(ServerSpeedLogList[0].avgDownloadBytes);
            labelSpeedUpValue.Text = FormatBytes(ServerSpeedLogList[0].avgUploadBytes);
        }

        public void UpdateLog()
        {
            if (workerThread == null)
            {
                workerThread = new Thread(this.UpdateLogThread);
                workerThread.Start();
            }
            else
            {
                workerEvent.Set();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (updatePause > 0)
            {
                updatePause -= 1;
                return;
            }
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (++pendingUpdate < 40)
                {
                    return;
                }
            }
            else
            {
                ++updateTick;
            }
            pendingUpdate = 0;
            if (ServerSpeedLogList != null)
            {
                RefreshLog();
            }
            
            UpdateLog();
            if (updateSize > 1) --updateSize;
            if (updateTick == 2 || updateSize == 1)
            {
                updateSize = 0;
                //autosizeColumns();
            }
        }


        void updateFreeNodeChecker_NewFreeNodeFound(object sender, EventArgs e)
        {
            int count = 0;
            if (!String.IsNullOrEmpty(updateFreeNodeChecker.FreeNodeResult))
            {
                List<string> urls = new List<string>();
                //MessageBox.Show(updateFreeNodeChecker.FreeNodeResult);
                updateFreeNodeChecker.FreeNodeResult = updateFreeNodeChecker.FreeNodeResult.TrimEnd('\r', '\n', ' ');
                Configuration config = controller.GetCurrentConfiguration();
                Server selected_server = null;
                if (config.index >= 0 && config.index < config.configs.Count)
                {
                    selected_server = config.configs[config.index];
                }
                try
                {
                    updateFreeNodeChecker.FreeNodeResult = Util.Base64.DecodeBase64(updateFreeNodeChecker.FreeNodeResult);
                }
                catch
                {
                    updateFreeNodeChecker.FreeNodeResult = "";
                }
                int max_node_num = 0;
                //MessageBox.Show(updateFreeNodeChecker.FreeNodeResult);
                Match match_maxnum = Regex.Match(updateFreeNodeChecker.FreeNodeResult, "^MAX=([0-9]+)");
                if (match_maxnum.Success)
                {
                    try
                    {
                        max_node_num = Convert.ToInt32(match_maxnum.Groups[1].Value, 10);
                    }
                    catch
                    {

                    }
                }
                Utils.URL_Split(updateFreeNodeChecker.FreeNodeResult, ref urls);
                for (int i = urls.Count - 1; i >= 0; --i)
                {
                    if (!urls[i].StartsWith("ssr"))
                        urls.RemoveAt(i);
                }
                if (urls.Count > 0)
                {
                    bool keep_selected_server = false; // set 'false' if import all nodes
                    if (max_node_num <= 0 || max_node_num >= urls.Count)
                    {
                        urls.Reverse();
                    }
                    else
                    {
                        Random r = new Random();
                        Util.Utils.Shuffle(urls, r);
                        urls.RemoveRange(max_node_num, urls.Count - max_node_num);
                        if (!config.isDefaultConfig())
                            keep_selected_server = true;
                    }
                    string lastGroup = null;
                    string curGroup = null;
                    foreach (string url in urls)
                    {
                        try // try get group name
                        {
                            Server server = new Server(url, null);
                            if (!String.IsNullOrEmpty(server.group))
                            {
                                curGroup = server.group;
                                break;
                            }
                        }
                        catch
                        { }
                    }
                    string subscribeURL = updateSubscribeManager.URL;
                    if (String.IsNullOrEmpty(curGroup))
                    {
                        curGroup = subscribeURL;
                    }
                    for (int i = 0; i < config.serverSubscribes.Count; ++i)
                    {
                        if (subscribeURL == config.serverSubscribes[i].URL)
                        {
                            lastGroup = config.serverSubscribes[i].Group;
                            config.serverSubscribes[i].Group = curGroup;
                            break;
                        }
                    }
                    if (lastGroup == null)
                    {
                        lastGroup = curGroup;
                    }

                    if (keep_selected_server && selected_server.group == curGroup)
                    {
                        bool match = false;
                        for (int i = 0; i < urls.Count; ++i)
                        {
                            try
                            {
                                Server server = new Server(urls[i], null);
                                if (selected_server.isMatchServer(server))
                                {
                                    match = true;
                                    break;
                                }
                            }
                            catch
                            { }
                        }
                        if (!match)
                        {
                            urls.RemoveAt(0);
                            urls.Add(selected_server.GetSSRLinkForServer());
                        }
                    }

                    // import all, find difference
                    {
                        Dictionary<string, Server> old_servers = new Dictionary<string, Server>();
                        if (!String.IsNullOrEmpty(lastGroup))
                        {
                            for (int i = config.configs.Count - 1; i >= 0; --i)
                            {
                                if (lastGroup == config.configs[i].group)
                                {
                                    old_servers[config.configs[i].id] = config.configs[i];
                                }
                            }
                        }
                        foreach (string url in urls)
                        {
                            try
                            {
                                Server server = new Server(url, curGroup);
                                bool match = false;
                                foreach (KeyValuePair<string, Server> pair in old_servers)
                                {
                                    if (server.isMatchServer(pair.Value))
                                    {
                                        match = true;
                                        old_servers.Remove(pair.Key);
                                        pair.Value.CopyServerInfo(server);
                                        ++count;
                                        break;
                                    }
                                }
                                if (!match)
                                {
                                    config.configs.Add(server);
                                    ++count;
                                }
                            }
                            catch
                            { }
                        }
                        foreach (KeyValuePair<string, Server> pair in old_servers)
                        {
                            for (int i = config.configs.Count - 1; i >= 0; --i)
                            {
                                if (config.configs[i].id == pair.Key)
                                {
                                    config.configs.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                        controller.SaveServersConfig(config);
                    }
                    config = controller.GetCurrentConfiguration();
                    if (selected_server != null)
                    {
                        bool match = false;
                        for (int i = config.configs.Count - 1; i >= 0; --i)
                        {
                            if (config.configs[i].id == selected_server.id)
                            {
                                config.index = i;
                                match = true;
                                break;
                            }
                            else if (config.configs[i].group == selected_server.group)
                            {
                                if (config.configs[i].isMatchServer(selected_server))
                                {
                                    config.index = i;
                                    match = true;
                                    break;
                                }
                            }
                        }
                        if (!match)
                        {
                            config.index = config.configs.Count - 1;
                        }
                    }
                    else
                    {
                        config.index = config.configs.Count - 1;
                    }
                    controller.SaveServersConfig(config);

                }
            }
            if (count > 0)
            {
                ShowBalloonTip(I18N.GetString("Success"),
                    I18N.GetString("Update subscribe SSR node success"), ToolTipIcon.Info, 10000);
            }
            else
            {
                ShowBalloonTip(I18N.GetString("Error"),
                    I18N.GetString("Update subscribe SSR node failure"), ToolTipIcon.Info, 10000);
            }
            if (updateSubscribeManager.Next())
            {

            }
        }

        void ShowBalloonTip(string title, string content, ToolTipIcon icon, int timeout)
        {
            _notifyIcon.BalloonTipTitle = title;
            _notifyIcon.BalloonTipText = content;
            _notifyIcon.BalloonTipIcon = icon;
            _notifyIcon.ShowBalloonTip(timeout);
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGlobalLogForm();
        }

        private void serverEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowConfigForm(false);
        }

        private void serverImportFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Import.CopyAddress_Click(this, new EventArgs());
        }


        private void testAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConnectTest.hasInternetAccess())
            {
                show_ping();
            }
        }

        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowServerLogForm();
        }

        private void updateFromSubscribeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConnectTest.hasInternetAccess())
            {
                Thread t = new Thread(() =>
                {
                    updateSubscribeManager.CreateTask(controller.GetCurrentConfiguration(), updateFreeNodeChecker, -1, false);
                });
                t.Start();
            }
        }


        private void subscribeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSubscribeSettingForm();
        }

        private void ButtonTest_Click(object sender, EventArgs e)
        {
            if (ConnectTest.hasInternetAccess())
            {
                show_ping();
            }
        }

        private void ButtonSocksPortAction_Click(object sender, EventArgs e)
        {
            if (numericUpDownSocksPort.ReadOnly == true)
            {
                numericUpDownSocksPort.ReadOnly = false;
                buttonSocksPortAction.Text = I18N.GetString("Save");
            } else
            {
                Configuration c = controller.GetConfiguration();
                c.localPort = (int)numericUpDownSocksPort.Value;
                controller.SaveServersConfig(c);
                numericUpDownSocksPort.ReadOnly = true;
                buttonSocksPortAction.Text = I18N.GetString("Edit");
            }
        }
    }

    class my_param
    {
        public string ip;
        public Int32 port;
        public int i;
        public int method;
    }
}
