using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace WebCore.SqlScripts
{
    public class ScriptHelper
    {

        public string Read(string path)
        {
            FileInfo file = new FileInfo(path);
            string sqlQuery = file.OpenText().ReadToEnd();

            return sqlQuery;
        }


    }
}
