namespace GymPL.Helper
{
    public static class UploadFiles
    {
        public static string Upload(string DirName, IFormFile file)
        {
            try
            {
                //1) Get Directory
                string basePath = Directory.GetCurrentDirectory();
                string FolderPath = Path.Combine(basePath, "wwwroot", DirName);

                ////2)Get File
                string FileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                //Compine
                string FullPath = Path.Combine(FolderPath, FileName);

                using (var s = new FileStream(FullPath, FileMode.Create))
                {
                    //Copy on Database
                    file.CopyTo(s);
                }
                return FileName;
            }
            catch
            (Exception e)
            {
                return e.Message;
            }
        }

        public static string RemoveFile(string DirName, string FileName)
        {
            try
            {

                var existFile = Path.Combine(Directory.GetCurrentDirectory(), "/wwwroot/images", DirName, FileName);

                if (File.Exists(existFile))
                {
                    File.Delete(existFile);
                    return "File Deleted";
                }
                else
                {
                    return "File Not Found";
                }
            }
            catch (Exception e) { return e.Message; }
        }
    }
}
