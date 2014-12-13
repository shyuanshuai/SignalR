using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace SignalR.SignalR {
    public class ServiceHub : Hub {

        // 当前在线人员
        public static Dictionary<string, string> OnLineUsers = new Dictionary<string, string>();

        // 进入系统连接时
        public void OnConnection(string name) {

            name = HttpUtility.HtmlEncode(name);
            string id = Context.ConnectionId;

            OnLineUsers.Add(id, name);

            Clients.Others.HelloEveryOne(name + " 上线了");
            Clients.Caller.HelloSelf(name + "登录成功");

        }

        // 离开系统时
        public override Task OnDisconnected(bool stopCalled) {

            OnLineUsers.Remove(Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        // 给所有人发消息
        public void SendMessageToAll(string name, string message) {

            Clients.All.SendAllMessage(name, message);

        }

        // 给指定人发消息
        public void SendMessageToOne(string id, string message) {

            string user = OnLineUsers[Context.ConnectionId];
            string toUser = OnLineUsers[id];

            Clients.Client(id).SendMessage(user + " 对 " + toUser + " 说："  + message);

        }



    }
}