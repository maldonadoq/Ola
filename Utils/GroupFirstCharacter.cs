using Phonebook.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Utils
{
    internal class GroupFirstCharacter : GroupDescription
    {
        public override object GroupNameFromItem(object item, int level, CultureInfo culture)
        {
            Contact? v = item as Contact;

            if (v != null)
            {
                return v.name[0];
            }
            return item;
        }
    }
}
