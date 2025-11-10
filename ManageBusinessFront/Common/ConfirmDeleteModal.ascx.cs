using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Web.UI;

namespace ManageBusinessFront.Common
{
    public partial class ConfirmDeleteModal : UserControl
    {
        public event EventHandler<string> OnDeleteConfirmed;

        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            string objectId = hfObjectId.Value;
            OnDeleteConfirmed?.Invoke(this, objectId);
        }

        public void SetObjectId(string id)
        {
            hfObjectId.Value = id;
        }
    }
}
