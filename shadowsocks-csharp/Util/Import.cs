using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shadowsocks.Controller;

namespace Shadowsocks.Util
{
    class Import
    {

        public static void CopyAddress_Click(object sender, EventArgs e)
        {
            ShadowsocksController controller = new ShadowsocksController();
            Console.WriteLine("Import server!");
            try
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    Console.WriteLine((string)iData.GetData(DataFormats.Text));
                    List<string> urls = new List<string>();
                    Utils.URL_Split((string)iData.GetData(DataFormats.Text), ref urls);
                    int count = 0;
                    Console.WriteLine(urls[0]);
                    foreach (string url in urls)
                    {
                        if (controller.AddServerBySSURL(url))
                            ++count;
                    }
                    if (count > 0)
                        Console.WriteLine("Import " + count.ToString() + " servers!");
                }
            }
            catch
            {

            }
        }


    }
}
