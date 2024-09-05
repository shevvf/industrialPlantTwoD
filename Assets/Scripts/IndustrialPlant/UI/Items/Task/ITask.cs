using System.Xml.Serialization;

namespace IndustrialPlant.UI.Items.Task
{
    public interface ITask
    {       
        void Lock();
        void Unlock ();
        void Complete();
    }
}