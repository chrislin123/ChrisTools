using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace M10.lib
{

  public class clsWinrar
  {
    private bool _Wait = false;
    MyEnum _size = MyEnum.g3;

    public enum MyEnum
    {
      g3,
      m900
    }

    public MyEnum size
    {
      get { return _size; }
      set { _size = value; }
    }


    public bool Wait
    {
      get { return _Wait; }
      set { _Wait = value; }
    }


    /// <summary>
    /// 是否安装了Winrar
    /// </summary>
    /// <returns></returns>
    static public bool Exists()
    {
      RegistryKey the_Reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
      return !string.IsNullOrEmpty(the_Reg.GetValue("").ToString());
    }

    /// <summary>
    /// 打包成Rar
    /// </summary>
    /// <param name="patch"></param>
    /// <param name="rarPatch"></param>
    /// <param name="rarName"></param>
    public void CompressRAR(string RARpatch, string SourcePatch)
    {
      string the_rar;
      RegistryKey the_Reg;
      object the_Obj;
      string the_Info = string.Empty;
      ProcessStartInfo the_StartInfo;
      Process the_Process;
      try
      {
        the_Reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
        the_Obj = the_Reg.GetValue("");
        the_rar = the_Obj.ToString();
        the_Reg.Close();
        //the_rar = the_rar.Substring(1, the_rar.Length - 7);
        //Directory.CreateDirectory(patch);
        //命令参数
        //the_Info = " a    " + rarName + " " + @"C:Test?70821.txt"; //文件压缩


        if (_size == MyEnum.g3)
        {
          //批次壓縮成3G
          the_Info = " a -r -ep1 -v3g -IBCK " + RARpatch + @".rar """ + SourcePatch + @""" ";
        }
        else if (_size == MyEnum.m900)
        {
          //批次壓縮成990mb
          the_Info = " a -r -ep1 -v990m -IBCK  " + RARpatch + @".rar """ + SourcePatch + @""" ";
        }




        the_StartInfo = new ProcessStartInfo();
        the_StartInfo.FileName = the_rar;
        the_StartInfo.Arguments = the_Info;
        //the_StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //打包文件存放目录
        //the_StartInfo.WorkingDirectory = rarPatch;
        the_Process = new Process();
        the_Process.StartInfo = the_StartInfo;
        the_Process.Start();
        if (_Wait)
        {
          the_Process.WaitForExit();
          the_Process.Close();
        }

      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    /// <summary>
    /// 解壓
    /// </summary>
    /// <param name="unRarPatch"></param>
    /// <param name="rarPatch"></param>
    /// <param name="rarName"></param>
    /// <returns></returns>
    public string unCompressRAR(string unRarPatch, string rarPatch, string rarName)
    {
      string the_rar;
      RegistryKey the_Reg;
      object the_Obj;
      string the_Info;
      

      try
      {
        the_Reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
        the_Obj = the_Reg.GetValue("");
        the_rar = the_Obj.ToString();
        the_Reg.Close();
        //the_rar = the_rar.Substring(1, the_rar.Length - 7);

        if (Directory.Exists(unRarPatch) == false)
        {
          Directory.CreateDirectory(unRarPatch);
        }
        the_Info = "x " + rarName + " -ppass@word1 " + unRarPatch + " -y";

        ProcessStartInfo the_StartInfo = new ProcessStartInfo();
        the_StartInfo.FileName = the_rar;
        the_StartInfo.Arguments = the_Info;
        the_StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        the_StartInfo.WorkingDirectory = rarPatch;//获取压缩包路径

        Process the_Process = new Process();
        the_Process.StartInfo = the_StartInfo;
        the_Process.Start();
        the_Process.WaitForExit();
        the_Process.Close();
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return unRarPatch;
    }



    /// <summary>
    /// 解壓
    /// </summary>
    /// <param name="unRarPatch"></param>
    /// <param name="rarPatch"></param>
    /// <param name="rarName"></param>
    /// <returns></returns>
    public string unCompressRAR(FileInfo fiTarget, DirectoryInfo diDest, string sPassword)
    {
      string the_rar;
      RegistryKey the_Reg;
      object the_Obj;
      string the_Info;


      try
      {
        the_Reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
        the_Obj = the_Reg.GetValue("");
        the_rar = the_Obj.ToString();
        the_Reg.Close();
        //the_rar = the_rar.Substring(1, the_rar.Length - 7);


        fiTarget.Directory.Create();

        //if (Directory.Exists(unRarPatch) == false)
        //{
        //  Directory.CreateDirectory(unRarPatch);
        //}
        the_Info = "x " + fiTarget.Name + " -ppass@word1 " + diDest.FullName + " -y";

        ProcessStartInfo the_StartInfo = new ProcessStartInfo();
        the_StartInfo.FileName = the_rar;
        the_StartInfo.Arguments = the_Info;
        the_StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        the_StartInfo.WorkingDirectory = fiTarget.DirectoryName;//获取压缩包路径

        Process the_Process = new Process();
        the_Process.StartInfo = the_StartInfo;
        the_Process.Start();
        the_Process.WaitForExit();
        the_Process.Close();
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return "";
    }
  }
}
