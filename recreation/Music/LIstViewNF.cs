using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rocoDB
{
    public partial class LIstViewNF : ListView
    {


        ///<summary>
        /// 前台行集合
        ///</summary>
        public List<ListViewItem> CurrentCacheItemsSource;

        public LIstViewNF()
        {
            InitializeComponent();
            // 开启双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            // Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }


        public LIstViewNF(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        public void LoadListViewItems(List<ListViewItem> items)
        {
            CurrentCacheItemsSource = null;

            this.Items.Clear();

            CurrentCacheItemsSource = new List<ListViewItem>();
            CurrentCacheItemsSource = items;
            this.VirtualListSize = items.Count;
            this.VirtualMode = true;
            this.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(listView_RetrieveVirtualItem);

        }



        private void listView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (this.CurrentCacheItemsSource == null || this.CurrentCacheItemsSource.Count == 0)
            {
                return;
            }

            e.Item = this.CurrentCacheItemsSource[e.ItemIndex];
            //Items[e.ItemIndex].EnsureVisible();
            
            if (e.ItemIndex == this.CurrentCacheItemsSource.Count)
            {
                this.CurrentCacheItemsSource = null;
            }           
        }


        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int ShowScrollBar(IntPtr hWnd, int iBar, int bShow);
        const int SB_HORZ = 0;
        const int SB_VERT = 1;
        protected override void WndProc(ref Message m)
        {
            if (this.View == View.List || this.View == View.Details)
            {
                ShowScrollBar(this.Handle, SB_HORZ, 0);
            }
            base.WndProc(ref m);
        }


        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
}
