using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_example
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void toolBtnRun_Click(object sender, EventArgs e)
        {
            tvVariable.Nodes.Clear();
            ScriptEngine engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            engine.Runtime.IO.RedirectToConsole();

            var paths = engine.GetSearchPaths();
            paths.Add(@"C:\Program Files\IronPython2\Lib");
            paths.Add(@"C:\Program Files\IronPython2\DLLs");
            //添加其他python库
            //...你的其他库路径
            engine.SetSearchPaths(paths);

            //直接执行py文件，并直接使用其中的类
            var script = engine.CreateScriptSourceFromString(tbCode.Text);
            script.Execute(scope);
            dynamic run =scope.GetVariable<Action>("Run");
            run();
            dynamic ipyTracer = scope.GetVariable<object>("ipyTracer");
           
            for (int i = 0; i < ipyTracer.WatchVariables.Count; i++)
            {
                
                dynamic obj = ipyTracer.WatchVariables[i];
                LoopAddWatchVaribles(null, obj,true);
                
            }
        }

        void LoopAddWatchVaribles(TreeNode parentNode,dynamic nodeObj,bool isUserDefine=false)
        {
            TreeNode treeNode;
            
            if (isUserDefine)
            {
                dynamic name = nodeObj.Name;
                DateTime dateTime = nodeObj.WatchTime;
                dynamic members = nodeObj.Value.get_members();
                dynamic objValue = nodeObj.Value.get_value();
                
                treeNode = new TreeNode($"[{dateTime.ToString("HH:mm:ss ffff")}]   标签:{name}   变量名:{nodeObj.Value.name}   类型:{nodeObj.Value.type}   变量值:{objValue}");
                foreach (var mm in members)
                {
                    if (mm.type != "instancemethod")
                    {
                        TreeNode childNode = new TreeNode($"变量名:{mm.name}   类型:{mm.type}   变量值:{mm.get_value()}");
                        treeNode.Nodes.Add(childNode);
                        LoopAddWatchVaribles(childNode, mm.get_value_ref(), false);
                    }
                }
            }
            else
            {

                try
                {
                    treeNode = new TreeNode($"变量名:{nodeObj.name}   类型:{nodeObj.type}   变量值:{nodeObj.get_value()}");
                }
                catch (Exception)
                {
                    return;
                }
                dynamic members = nodeObj.get_members();
                foreach (var mm in members)
                {
                    if (mm.type != "instancemethod")
                    {
                        TreeNode childNode = new TreeNode($"变量名:{mm.name}   类型:{mm.type}   变量值:{mm.get_value()}");
                        treeNode.Nodes.Add(childNode);
                        LoopAddWatchVaribles(childNode, mm.get_value_ref(), false);
                    }
                }
            }
            
            tvVariable.Nodes.Add(treeNode);
        }

        private void toolBtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Python脚本|*.py";
            dialog.Title = "打开当前脚本";
            dialog.Multiselect = false;
            if (dialog.ShowDialog()==DialogResult.OK)
            {
                var filename = dialog.FileName;
                using (StreamReader r=new StreamReader(filename))
                {
                    tbCode.Text =r.ReadToEnd();
                }
            }
        }

        private void toolBtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Python脚本|*.py";
            dialog.FileName = "新建脚本";
            dialog.AddExtension = true;
            dialog.DefaultExt = "py";
            dialog.Title = "保存当前脚本";
            if (dialog.ShowDialog()==DialogResult.OK)
            {
                using (StreamWriter w = new StreamWriter(dialog.FileName))
                {
                    w.WriteAsync(tbCode.Text);
                }
            }
        }
    }
}
