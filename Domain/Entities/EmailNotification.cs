using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmailNotification : BaseEntity
    {
        public string ToEmailUserName { get; set; }
        public string ToEmailAddress { get; set; }
        public string FromEmailUserName { get; set; }
        public string FromEmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Attachment { get; set; }
        public bool IsSuccessed { get; set; }

        public void UpdateEmailStatus(bool flag)
        {
            IsSuccessed = flag;
        }
    }
}
