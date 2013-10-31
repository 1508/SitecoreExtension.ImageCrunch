using System;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Shell.Applications.Dialogs.ProgressBoxes;
using Sitecore.Shell.Framework.Commands;

namespace SitecoreExtension.ImageCrunch.App.Commands
{
    public class ShrinkImage : Command
    {
        public override void Execute(CommandContext context)
        {
            if (!context.Items.Any(t => t.Paths.IsMediaItem))
            {
                return;
            }

            ProgressBox.Execute("Shrink Image", "Shrink Image", new ProgressBoxMethod(this.Shrink), new object[1]
            {
                context.Items[0]
            });

        }

        protected virtual void Shrink(object[] parameters)
        {
            Item item = parameters[0] as Item;

            if (item == null)
            {
                throw new Exception("Parameter 0 was not a item");
            }

            CrunchImage.ProcessMediaItem(item);
        }

        public override CommandState QueryState(CommandContext context)
        {

            if (context.Items.Any(t => t.Paths.IsMediaItem))
            {
                return CommandState.Enabled;
            }
            else
            {
                return CommandState.Disabled;
            }

            return base.QueryState(context);
        } 
    }
}