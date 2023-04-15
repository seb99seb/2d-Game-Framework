using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_library.Interfaces
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void ChangeStrategy(IStrategy strategy);
        void Notify(World world);
    }
}