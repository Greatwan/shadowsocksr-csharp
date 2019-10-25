using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using Shadowsocks.Controller;
using Shadowsocks.Util;

// For Api and json parse
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Shadowsocks.Model
{
    class Login
    {
        // private ShadowsocksController controller;

        // @TODO
        // 初次启动时，更新config会出错，需要退出后在menuviewcontroller里更新才有用，不知道为什么

        public static JObject GetToken(string email, string passwd)
        {
            if (!ConnectTest.hasInternetAccess())
            {
                return null;
            }

            ShadowsocksController controller = new ShadowsocksController();

            Configuration config = controller.GetCurrentConfiguration();
            string website = string.Empty;

            if (email == "" || passwd == "")
            {
                return null;
            }

            if (config.ApiUrl == "")
            {
                config.ApiUrl = Configuration.GetDefaultUrl(0);
                controller.SaveServersConfig(config);
            }

            bool use_proxy = config.ApiUpdateWithProxy;

            // 默认服务器无法更新， 故设为false
            if (config.index == 0 && config.configs[0].server == Configuration.GetDefaultServer().server)
            {
                Console.WriteLine("GetToken->default server -> use_proxy = false;");
                use_proxy = false;
                try
                {
                    website = ConnectTest.GetValidLoginUrlWithProxy(use_proxy);
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1);
                    website = config.ApiUrl;
                }
            }
            if (use_proxy)
            {
                if (!ConnectTest.isValidLocalSocks5Proxy())
                {
                    Console.WriteLine("GetToken->server invalid -> use_proxy = false;");
                    use_proxy = false;
                    // MessageBox.Show("! ConnectTest.isValidLocalSocks5Proxy()");
                    website = ConnectTest.getValidLoginUrlByTcping(use_proxy);
                }
            } else if (website == "")
            {
                Console.WriteLine(" 74 getToken -> use_proxy == false;");
                try
                {
                    website = ConnectTest.GetValidLoginUrlWithProxy(use_proxy);
                    if (website == "")
                    {
                        Console.WriteLine("80 getToken -> use_proxy == true;");
                        use_proxy = true;
                        website = ConnectTest.GetValidLoginUrlWithProxy(use_proxy);
                    }
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1);
                    Console.WriteLine("88 getToken -> use_proxy == true;");
                    use_proxy = true;
                    website = ConnectTest.GetValidLoginUrlWithProxy(use_proxy);
                }
            }

            Console.WriteLine("website " + website);

            if (website == "")
            {
                return null;
            }

            string str = string.Empty, result = string.Empty;
            website += "/api/getJwtToken";
            // MessageBox.Show("Website: "+website+" Email: "+email+ " Pass: " + passwd);
            try
            {
                WebClient wclient = new WebClient();
                wclient.BaseAddress = website;
                wclient.Encoding = Encoding.UTF8;
                wclient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.117 Safari/537.36");
                wclient.Headers.Add("Content-Type", "application/x-www-form-urlencoded\r\n");
                if (use_proxy)
                {
                    WebProxy proxy = new WebProxy(IPAddress.Loopback.ToString(), config.localPort);
                    //MessageBox.Show(IPAddress.Loopback.ToString()+config.localPort.ToString());
                    if (!string.IsNullOrEmpty(config.authPass))
                    {
                        proxy.Credentials = new NetworkCredential(config.authUser, config.authPass);
                    }
                    wclient.Proxy = proxy;
                }
                else
                {
                    wclient.Proxy = null;
                }

                string postData = "email=" + email + "&password=" + passwd;
                //Console.WriteLine("[INFO] "+website + " postData: " + postData);
                byte[] sendData = Encoding.GetEncoding("utf-8").GetBytes(postData.ToString());

                result = wclient.UploadString(website, postData);

                JObject jo = (JObject)JsonConvert.DeserializeObject(result);

                if (jo["ret"].ToString() != "1")
                {
                    //MessageBox.Show(jo.ToString());
                    Console.WriteLine(jo.ToString());
                    return null;
                }




                //UserInfo userinfo = new UserInfo();
                //userinfo.email = email;
                //userinfo.user_class = jo["data"]["class"].ToString();
                //userinfo.class_expire = jo["data"]["class_expire"].ToString();
                //userinfo.traffic_remain = jo["data"]["unusedTraffic"].ToString();
                ////controller.addUserInfo(userinfo);
                ////config.userInfos

                //if (config.userInfos.Count == 0)
                //{
                //    Console.WriteLine("Login.cs " + config.userInfos.Count);
                //    config.userInfos.Add(userinfo);
                //    Console.WriteLine("Login.cs config.userInfos.Add(userinfo);");
                //    Console.WriteLine("Login.cs " + config.userInfos.Count);
                //    //Configuration.Save(config);
                //    controller.SaveServersConfig(config);
                //    //Configuration.MergeConfiguration(_config);
                //}


                // 多个用户
                //int times = 0;
                //for (int i = 0; i < config.userInfos.Count; i++)
                //{
                //    times += 1;
                //    if (config.userInfos[i].email == userinfo.email)
                //    {
                //        config.userInfos[i] = userinfo;
                //        Console.WriteLine("edit UserInfo");
                //        //Configuration.Save(config);
                //        controller.SaveServersConfig(config);
                //        break;
                //        //SaveConfig(_config);
                //    }
                //}
                //if (times == config.userInfos.Count)
                //{
                //    config.userInfos.Add(userinfo);
                //    Console.WriteLine("add UserInfo");
                //    //    Configuration.Save(config);
                //    controller.SaveServersConfig(config);
                //}


                return jo;

            } catch (Exception api_e) {
                //MessageBox.Show(api_e.ToString());
                Console.WriteLine(api_e.ToString());
                return null;
            }
        }

        public static JObject GetLoginJObject(ShadowsocksController controller, int userIndex)
        {
            if (!ConnectTest.hasInternetAccess())
            {
                return null;
            }
            
            Configuration config = controller.GetCurrentConfiguration();
            UserInfo userInfo = config.userInfos[userIndex];
            string  website=string.Empty ;

            if (userInfo.userEmail == "" || userInfo.userToken == "")
            {
                return null;
            }

            if (config.ApiUrl == "")
            {
                config.ApiUrl = Configuration.GetDefaultUrl(0);
                controller.SaveServersConfig(config);
            }

            bool use_proxy = config.ApiUpdateWithProxy;
            bool test_again = true;
            

            // 默认服务器无法更新， 故设为false
            if (config.index == 0 && config.configs[0].server == Configuration.GetDefaultServer().server)
            {
                Console.WriteLine("GetLoginJObject->default server -> use_proxy = false;");
                use_proxy = false;
                test_again = false;
                try
                {
                    website = ConnectTest.GetValidLoginUrlWithProxy(use_proxy);
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1);
                    website = config.ApiUrl;
                }
            }

            if (use_proxy==true && website == "")
            {
                if (!ConnectTest.isValidLocalSocks5Proxy())
                {
                    Console.WriteLine("GetLoginJObject->server invalid -> use_proxy = false;");
                    use_proxy = false;
                    // MessageBox.Show("! ConnectTest.isValidLocalSocks5Proxy()");
                    website = ConnectTest.getValidLoginUrlByTcping(use_proxy);
                    if (website == "")
                    {
                        Console.WriteLine("232 getToken -> use_proxy == true;");
                        use_proxy = true;
                        website = ConnectTest.GetValidLoginUrlWithProxy(use_proxy);
                    }
                } else
                {
                    Console.WriteLine("use_proxy = true;");
                    use_proxy = true;
                    // MessageBox.Show("! ConnectTest.isValidLocalSocks5Proxy()");
                    website = ConnectTest.getValidLoginUrlByTcping(use_proxy);
                }
            }
            else if (website == "")
            {
                Console.WriteLine(" 264 GetLoginJObject -> use_proxy == false;");
                try
                {
                    website = ConnectTest.GetValidLoginUrlWithProxy(use_proxy);
                    if (website == "")
                    {
                        Console.WriteLine("270 GetLoginJObject -> use_proxy == true;");
                        use_proxy = true;
                        website = ConnectTest.GetValidLoginUrlWithProxy(use_proxy);
                    }
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1);
                    Console.WriteLine("277 GetLoginJObject -> use_proxy == true;");
                    use_proxy = true;
                    website = ConnectTest.GetValidLoginUrlWithProxy(use_proxy);
                }

            }


            if (website == "")
            {
                return null;
            }

            string str = string.Empty, result = string.Empty;
            website += "/api/jwt/user/client_once";
            try
            {
                WebClient wclient = new WebClient();
                wclient.BaseAddress = website;
                wclient.Encoding = Encoding.UTF8;
                wclient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.117 Safari/537.36");
                wclient.Headers.Add("Authorization", userInfo.userToken);
                wclient.Headers.Add("Content-Type", "application/x-www-form-urlencoded\r\n");
                if (use_proxy)
                {
                    WebProxy proxy = new WebProxy(IPAddress.Loopback.ToString(), config.localPort);
                    //MessageBox.Show(IPAddress.Loopback.ToString()+config.localPort.ToString());
                    if (!string.IsNullOrEmpty(config.authPass))
                    {
                        proxy.Credentials = new NetworkCredential(config.authUser, config.authPass);
                    }
                    wclient.Proxy = proxy;
                }
                else
                {
                    wclient.Proxy = null;
                }

                //string postData = "email=" + email + "&passwd=" + passwd;
                ////Console.WriteLine("[INFO] "+website + " postData: " + postData);
                //byte[] sendData = Encoding.GetEncoding("utf-8").GetBytes(postData.ToString());

                result = wclient.UploadString(website, "");

                JObject jo = (JObject)JsonConvert.DeserializeObject(result);

                if (jo["ret"].ToString() != "1")
                {
                    //MessageBox.Show(jo.ToString());
                    Console.WriteLine(jo.ToString());
                    return null;
                }
                return jo;

            }
            catch (Exception api_e)
            {
                //MessageBox.Show(api_e.ToString());
                Console.WriteLine(api_e.ToString());
                return null;
            }
        }

        public static string RenewToken(int userIndex)
        {

            if (!ConnectTest.hasInternetAccess())
            {
                return "";
            }
            ShadowsocksController controller = new ShadowsocksController();
            Configuration config = controller.GetCurrentConfiguration();
            UserInfo userInfo = config.userInfos[userIndex];
            string website = string.Empty;
            if (userInfo.userEmail == "" || userInfo.userToken == "")
            {
                return "";
            }
            if (config.ApiUrl == "")
            {
                config.ApiUrl = Configuration.GetDefaultUrl(0);
                controller.SaveServersConfig(config);
            }
            bool use_proxy = config.ApiUpdateWithProxy;
            if (config.index == 0 && config.configs[0].server == Configuration.GetDefaultServer().server)
            {
                Console.WriteLine(" 323 RenewToken->default server -> use_proxy = false;");
                use_proxy = false;
                try
                {
                    website = ConnectTest.GetValidLoginUrlWithProxy(use_proxy);
                } catch (Exception e1)
                {
                    Console.WriteLine(e1);
                    website = config.ApiUrl;
                }
            }
            if (use_proxy)
            {
                Console.WriteLine("336 RenewToken -> use_proxy == true;");
                if (!ConnectTest.isValidLocalSocks5Proxy())
                {
                    Console.WriteLine("339 RenewToken->server invalid -> use_proxy = false;");
                    use_proxy = false;
                    // MessageBox.Show("! ConnectTest.isValidLocalSocks5Proxy()");
                    website = ConnectTest.getValidLoginUrlByTcping(use_proxy);
                }
            }
            else if (website == "")
            {
                Console.WriteLine(" 347 RenewToken -> use_proxy == false;");
                try
                {
                    website = ConnectTest.GetValidLoginUrlWithProxy(use_proxy);
                    if (website == "")
                    {
                        Console.WriteLine("353 RenewToken -> use_proxy == true;");
                        use_proxy = true;
                        website = ConnectTest.GetValidLoginUrlWithProxy(use_proxy);
                    }
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1);
                    Console.WriteLine("361 RenewToken -> use_proxy == true;");
                    use_proxy = true;
                    website = ConnectTest.GetValidLoginUrlWithProxy(use_proxy);
                }
            }

            if (website == "")
            {
                Console.WriteLine("369 website == ");
                return null;
            }
            Console.WriteLine("website " + website);
            string str = string.Empty, result = string.Empty;
            website += "/api/jwt/user/newToken";
            try
            {
                WebClient wclient = new WebClient();
                wclient.BaseAddress = website;
                wclient.Encoding = Encoding.UTF8;
                wclient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.117 Safari/537.36");
                wclient.Headers.Add("Authorization", userInfo.userToken);
                wclient.Headers.Add("Content-Type", "application/x-www-form-urlencoded\r\n");
                if (use_proxy)
                {
                    WebProxy proxy = new WebProxy(IPAddress.Loopback.ToString(), config.localPort);
                    //MessageBox.Show(IPAddress.Loopback.ToString()+config.localPort.ToString());
                    if (!string.IsNullOrEmpty(config.authPass))
                    {
                        proxy.Credentials = new NetworkCredential(config.authUser, config.authPass);
                    }
                    wclient.Proxy = proxy;
                }
                else
                {
                    wclient.Proxy = null;
                }

                //string postData = "email=" + email + "&passwd=" + passwd;
                ////Console.WriteLine("[INFO] "+website + " postData: " + postData);
                //byte[] sendData = Encoding.GetEncoding("utf-8").GetBytes(postData.ToString());

                result = wclient.UploadString(website, "");

                JObject jo = (JObject)JsonConvert.DeserializeObject(result);

                if (jo["ret"].ToString() != "1")
                {
                    //MessageBox.Show(jo.ToString());
                    Console.WriteLine(jo.ToString());
                    return "";
                }
                return jo["data"].ToString();
            }
            catch (Exception api_e)
            {
                //MessageBox.Show(api_e.ToString());
                Console.WriteLine(api_e.ToString());
                return "";
            }
            
        }

    }
}
