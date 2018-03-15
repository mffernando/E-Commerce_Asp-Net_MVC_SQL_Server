using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ECommerce.Class
{
    public class FileHelper
    {
        //imagem upload
        public static bool PhotoUpload(HttpPostedFileBase file, string folder, string name)
        {
            string path = string.Empty;
            //string pic = string.Empty;

            //verification if null or empty
            if (file == null || string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(name))
            {
                return false;
            }

            //if true
            try
            {
                if(file != null)
                {                
                    path = Path.Combine(HttpContext.Current.Server.MapPath(folder), name);
                    file.SaveAs(path);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }
                }
                return true;
            }
            
            catch (Exception)
            {
                return false;
            }
        }
    }
}