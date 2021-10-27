using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace LayoutArticle
{
    public class Customer : IHaveActions
    {
        public Customer()
        {
            FirstName = "Markus";
            LastName = "Egger";
            Company = "EPS/CODE";
            Phone = "832-717-4445";
            Email = "megger@eps-software.com";
            Position = "President & CSA";

            CreateActions();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }

        void CreateActions()
        {
            var actions = new List<IAction>();

            actions.Add(new Action(caption: "Save",
                                   visualResourceKey: "Icon-Save",
                                   execute: (a, o) => MessageBox.Show("Saving!")));

            actions.Add(new Action(caption: "New",
                                   visualResourceKey: "Icon-New",
                                   execute: (a, o) => MessageBox.Show("New!")));

            actions.Add(new Action(caption: "Delete",
                                   visualResourceKey: "Icon-Delete",
                                   execute: (a, o) => MessageBox.Show("Deleting!")));

            actions.Add(new Action(caption: "Close",
                                   visualResourceKey: "Icon-Close",
                                   beginGroup: true,
                                   execute: (a, o) => MessageBox.Show("Closing!")));

            Actions = actions;
        }

        public IEnumerable<IAction> Actions { get; private set; }
    }
}
