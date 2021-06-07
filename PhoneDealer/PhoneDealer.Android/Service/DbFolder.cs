using Android.OS;
using PhoneDealer.Droid.Service;
using PhoneDealer.Services;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DbFolder))]
namespace PhoneDealer.Droid.Service
{
    public class DbFolder : IDbFolder
    {
        public string CaminhoArquivo()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(path, "empresto.db");
        }
    }
}