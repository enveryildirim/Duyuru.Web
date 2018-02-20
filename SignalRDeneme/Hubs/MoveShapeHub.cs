using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
namespace SignalRDeneme
{
   [HubName("moveShape")]
   public class MoveShapeHub:Hub
    {
        public void Move(double x,double y)
        {
            Clients.Others.shapeMoved(x, y);
        }
        
    }
}
