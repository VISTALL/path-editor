using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using com.jds.PathEditor.classes.client;
using com.jds.PathEditor.classes.forms;
using com.jds.PathEditor.classes.lm;
using com.jds.PathEditor.classes.services;

namespace com.jds.PathEditor.classes.parser
{
    public class L2EncDec
    {
        public static BinaryReader Decrypt(string fname, Encoding enc)
        {
            var process_decoder = new Process();
            string decoder_output = "";

            string fname_encoded = Path.Combine(RConfig.Instance.LineageDirectory, fname);
            string fname_decoded = Path.GetTempFileName();

            try
            {
                process_decoder.StartInfo.FileName = Path.Combine(GlobalUtilities.GetStartDirectory(false),
                                                                  "l2encdec\\l2encdec.exe");
                process_decoder.StartInfo.UseShellExecute = false;
                process_decoder.StartInfo.CreateNoWindow = true;
                process_decoder.StartInfo.RedirectStandardOutput = true;
                process_decoder.StartInfo.Arguments = String.Format("-s \"{0}\" \"{1}\"", fname_encoded, fname_decoded);
                process_decoder.Start();
                process_decoder.WaitForExit();

                if (process_decoder.ExitCode < 0)
                {
                    // lets try with -g switch
                    process_decoder.StartInfo.Arguments = String.Format("-g \"{0}\" \"{1}\"", fname_encoded,
                                                                        fname_decoded);
                    process_decoder.Start();
                    process_decoder.WaitForExit();

                    if (process_decoder.ExitCode < 0)
                    {
                        // guess this file is not encrypted
                        fname_decoded = fname_encoded;
                    }
                }

                try
                {
                    decoder_output = process_decoder.StandardOutput.ReadToEnd();
                }
                catch
                {
                    return null;
                }

                return new BinaryReader(File.OpenRead(fname_decoded), enc);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    String.Format("Error decoding '{0}':\n\n{1}", fname_encoded, decoder_output), ex);
            }
            finally
            {
                process_decoder.Dispose();
            }

            return null;
        }

        public static void Encrypt(string fname, Int32 coding)
        {
            var process_encoder = new Process();
            string encoder_output = "";

            string fname_encoded = Path.Combine(RConfig.Instance.LineageDirectory, fname);
            string fname_decoded = Path.ChangeExtension(fname_encoded, "tmp");

            try
            {
                File.Delete(fname_decoded);
                File.Move(fname_encoded, fname_decoded);

                process_encoder.StartInfo.FileName = Path.Combine(GlobalUtilities.GetStartDirectory(false),
                                                                  @"l2encdec\l2encdec.exe");
                process_encoder.StartInfo.UseShellExecute = false;
                process_encoder.StartInfo.CreateNoWindow = true;
                process_encoder.StartInfo.RedirectStandardOutput = true;
                process_encoder.StartInfo.Arguments = String.Format("{0} \"{1}\" \"{2}\"", "-h " + coding, fname_decoded,
                                                                    fname_encoded);
                process_encoder.Start();
                process_encoder.WaitForExit();

                try
                {
                    encoder_output = process_encoder.StandardOutput.ReadToEnd();
                }
                catch
                {
                }

                File.Delete(fname_decoded);
            }
            catch (Exception ex)
            {
                try
                {
                    File.Move(fname_decoded, fname_encoded);
                }
                catch
                {
                }

                throw new ApplicationException(
                    String.Format("Error encoding '{0}':\n\n{1}", fname_decoded, encoder_output), ex);
            }
            finally
            {
                process_encoder.Dispose();
            }
        }

        public static void SystemPatcher()
        {
            var process_patcher = new Process();
            string patcher_output = "";

            string fname_l2encdec = Path.Combine(GlobalUtilities.GetStartDirectory(false), @"l2encdec\l2encdec.exe");
            string fname_libdll = Path.Combine(GlobalUtilities.GetStartDirectory(false), @"l2encdec\libgmp-3.dll");
            string fname_patcher = Path.Combine(GlobalUtilities.GetStartDirectory(false), @"l2encdec\patcher.exe");
            string fname_loader = Path.Combine(GlobalUtilities.GetStartDirectory(false), @"l2encdec\loaderCT1.exe");

            if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Gracia_1__Gracia_2)
                fname_loader = Path.Combine(GlobalUtilities.GetStartDirectory(false), @"l2encdec\loaderCT1++.exe");

            string l2exe_file = "";

            try
            {
                // Create Backup Folder
                Boolean back_flg = false;
                string backup_folder = Path.Combine(RConfig.Instance.LineageDirectory, "backup");
                if (Directory.Exists(backup_folder))
                    back_flg = true;
                else
                    Directory.CreateDirectory(backup_folder);

                // Create Temp Folder
                string temp_folder = Path.Combine(RConfig.Instance.LineageDirectory, "tmp");
                if (Directory.Exists(temp_folder))
                    Directory.Delete(temp_folder, true);
                Directory.CreateDirectory(temp_folder);

                // Install l2encdec.exe
                File.Copy(fname_l2encdec,
                          Path.Combine(RConfig.Instance.LineageDirectory, Path.GetFileName(fname_l2encdec)), true);
                File.Copy(fname_libdll, Path.Combine(RConfig.Instance.LineageDirectory, Path.GetFileName(fname_libdll)),
                          true);
                process_patcher.StartInfo.WorkingDirectory = RConfig.Instance.LineageDirectory;
                process_patcher.StartInfo.FileName = Path.Combine(RConfig.Instance.LineageDirectory,
                                                                  Path.GetFileName(fname_l2encdec));
                process_patcher.StartInfo.UseShellExecute = false;
                process_patcher.StartInfo.CreateNoWindow = true;
                process_patcher.StartInfo.RedirectStandardOutput = true;

                // Decrypt & Encrypt by l2encdec.exe
                var current = new DirectoryInfo(RConfig.Instance.LineageDirectory);

                int currentFiles = 0;
                MainForm.Instance.onStart(current.GetFiles().Length);

                foreach (FileInfo file in current.GetFiles())
                {
                    string current_file = Path.GetFileName(file.FullName);
                    string backup_file = Path.Combine(backup_folder, current_file);

                    // Check Header
                    var f = new BinaryReader(File.OpenRead(file.FullName), Encoding.Default);
                    string FileHeader = "";
                    if (f.BaseStream.Length > 28)
                    {
                        byte[] buf = f.ReadBytes(28);
                        for (int i = 0; i < 28; i++)
                        {
                            if (buf[i] == 0x00) continue;
                            FileHeader += Convert.ToChar(buf[i]);
                        }
                    }
                    f.Close();
                    if (FileHeader == "Lineage2Ver413")
                    {
                        if (!back_flg)
                            File.Copy(file.FullName, backup_file, true);

                        // Decrypt
                        process_patcher.StartInfo.Arguments = String.Format("-s \"{0}\" \"{1}\"",
                                                                            current_file,
                                                                            Path.ChangeExtension(current_file, ".dec"));
                        process_patcher.Start();
                        process_patcher.WaitForExit();
                        if (process_patcher.ExitCode < 0)
                        {
                            // lets try with -g switch
                            process_patcher.StartInfo.Arguments = String.Format("-g \"{0}\" \"{1}\"",
                                                                                current_file,
                                                                                Path.ChangeExtension(current_file,
                                                                                                     ".dec"));
                            process_patcher.Start();
                            process_patcher.WaitForExit();
                            if (process_patcher.ExitCode < 0)
                            {
                                new MessageBox(String.Format("Error patching.\n\n{0}", patcher_output));
                                break;
                            }
                        }

                        // Encrypt
                        process_patcher.StartInfo.Arguments = String.Format("{0} \"{1}\" \"{2}\"",
                                                                            "-h 413",
                                                                            Path.ChangeExtension(current_file, ".dec"),
                                                                            current_file);
                        process_patcher.Start();
                        process_patcher.WaitForExit();
                        if (process_patcher.ExitCode < 0)
                        {
                            new MessageBox(String.Format("Error patching.\n\n{0}", patcher_output));
                            break;
                        }

                        File.Delete(Path.Combine(RConfig.Instance.LineageDirectory,
                                                 Path.ChangeExtension(current_file, ".dec")));
                    }
                    else
                    {
                        if (current_file.ToLower() == "l2.exe")
                        {
                            l2exe_file = current_file;
                            File.Copy(file.FullName, Path.Combine(temp_folder, current_file));
                            if (!back_flg)
                                File.Copy(file.FullName, backup_file, true);
                        }
                    }
                    currentFiles++;

                    MainForm.Instance.setValue(currentFiles);
                }

                if (l2exe_file != "")
                {
                    // Install patcher.exe 
                    File.Copy(fname_patcher, Path.Combine(temp_folder, Path.GetFileName(fname_patcher)));
                    process_patcher.StartInfo.WorkingDirectory = temp_folder;
                    process_patcher.StartInfo.FileName = Path.Combine(temp_folder, Path.GetFileName(fname_patcher));
                    process_patcher.StartInfo.Arguments = "-f";
                    process_patcher.Start();
                    process_patcher.WaitForExit();
                    File.Copy(Path.Combine(temp_folder, l2exe_file),
                              Path.Combine(RConfig.Instance.LineageDirectory, l2exe_file), true);

                    // Install loaderCT1.exe
                    if (RConfig.Instance.DatVersionAsEnum >= DatVersion.Kamael)
                    {
                        File.Copy(fname_loader,
                                  Path.Combine(RConfig.Instance.LineageDirectory, Path.GetFileName(fname_loader)), true);
                    }
                }

                // Cleanup Files
                File.Delete(Path.Combine(RConfig.Instance.LineageDirectory, "l2encdec.exe"));
                File.Delete(Path.Combine(RConfig.Instance.LineageDirectory, "libgmp-3.dll"));

                if (Directory.Exists(temp_folder))
                {
                    Directory.Delete(temp_folder, true);
                }

                MainForm.Instance.onEnd();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    String.Format("Error patching.\n\n{0}", patcher_output), ex);
            }
            finally
            {
                process_patcher.Dispose();
            }
        }
    }
}