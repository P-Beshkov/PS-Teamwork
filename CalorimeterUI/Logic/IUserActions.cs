using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public interface IUserActions
    {
        void SaveHistory();
        void LoadHistory();
        void AddToHistory(NutritionData item);
        string ShowDetailedHistory();        
    }
}
