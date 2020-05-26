using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NbSites.Common;

namespace NbSites.Web.Libs.Updates
{
    public interface IUpdateHelper
    {
        bool NeedUpdate();
        MessageResult Update();
    }

    public class UpdateHelper : IUpdateHelper
    {
        public bool NeedUpdate()
        {
            //todo by need
            return false;
        }

        public MessageResult Update()
        {
            //a demo for auto load or unload Area:Demo
            var root = AppDomain.CurrentDomain.BaseDirectory;
            var updateResults = new List<MessageResult>();
            updateResults.Add(UpdateForArea(root, "Demo", "dll"));
            updateResults.Add(UpdateForArea(root, "Demo", "pdb"));

            var results = updateResults.ToBatchResults();
            return results;
        }

        private MessageResult UpdateForArea(string root, string area, string lastFix)
        {
            var updateResult = new MessageResult();
            var searchPattern = $"*.{area}.{lastFix}.bak";
            var bakFile = Directory.GetFiles(root, searchPattern).FirstOrDefault();
            if (bakFile != null)
            {
                var deleteAreaFile = bakFile.Replace(".bak", "");
                if (File.Exists(deleteAreaFile))
                {
                    File.Delete(deleteAreaFile);
                }
                File.Move(bakFile, deleteAreaFile);
                updateResult.Message = "Load DEMO";
                updateResult.Success = true;
                return updateResult;
            }

            var areaFilePattern = $"*.{area}.{lastFix}";
            var areaFile = Directory.GetFiles(root, areaFilePattern).FirstOrDefault();
            if (areaFile != null)
            {
                File.Move(areaFile, areaFile + ".bak");
                updateResult.Success = true;
                updateResult.Message = "Unload DEMO";
                return updateResult;
            }

            updateResult.Message = "NotFindUpdateFiles: " + area;
            return updateResult;
        }

        private static readonly Lazy<IUpdateHelper> _lazy = new Lazy<IUpdateHelper>(() => new UpdateHelper());
        public static Func<IUpdateHelper> Resolve = () => _lazy.Value;
    }
}
