using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LinkStart.Core;
using LinkStart.Core.Models;
using LinkStart.Persistence;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;

namespace LinkStart.Hub
{

    public class LinkChatHub : Microsoft.AspNet.SignalR.Hub
    {
      

        public void SendMessage(string chatName, string message)
        {
            /* if (message.StartsWith("@"))
             {
                 var pmUsername = message.Split(' ')[0].Substring(1);

                 var pmConnection = await _unitOfWork.ConnectionRepository.GetConnection(pmUsername);

                 if (pmConnection!=null)
                 {
                     Clients.Clients(new List<string> {Context.ConnectionId, pmConnection.ConnectionId})
                         .UpdateChat(userName, message, true);
                     return;
                 }
             }*/



            if (message.StartsWith("@"))
            {
                var pmUserName = message.Split(' ')[0].Substring(1);

                using (var db = new ApplicationDbContext())
                {
                    var pmConnection = db.Connections.Where(x => x.ChatName.ToLower() == pmUserName && x.IsOnline)
                        .SingleOrDefault();

                    if (pmConnection != null)
                    {
                        Clients.Clients(new List<string> { Context.ConnectionId, pmConnection.ConnectionId })
                            .UpdateChat(chatName, message, true);
                        return;
                    }
                }
            }
            Clients.All.UpdateChat(chatName, message);
        }

        public void UsersOnline()
        {
            try
            {
                /*  Clients.All.UpdateUsersOnline(new
                  {
                      Success = true,
                      UsersOnline = await _unitOfWork.ConnectionRepository.GetOnlineUsers()
                  });
  */
              

                using (var db = new ApplicationDbContext())
                {
                    Clients.All.UpdateUsersOnline(new
                    {
                        Success = true,
                        UsersOnline = db.Connections.Where(x => x.IsOnline).Select(x => x.ChatName).ToArray()
                    });
                }
            }
            catch (Exception e)
            {
                Clients.All.UpdateUserOnline(new
                {
                    Success = false,
                    ErrorMessage = e.Message
                });
            }
        }

        public  object ConnectUser(string chatName)
        {
            try
            {
                /*        var exstConnection = await _unitOfWork.ConnectionRepository.GetExistingConnection(userId);

                        if (exstConnection!=null)
                        {
                            exstConnection.ConnectionId = Context.ConnectionId;
                            exstConnection.IsOnline = true;
                        }
                        else
                        {
                            var connection = new Connection
                            {
                                ConnectionId = Context.ConnectionId,
                                UserId = userId,
                                IsOnline = true
                            };
                             _unitOfWork.ConnectionRepository.Add(connection);
                        }

                       await _unitOfWork.Complete();

                      await  UsersOnline();

                        return new {Success = true};*/

                var userId = Context.User.Identity.GetUserId();
                using (var db = new ApplicationDbContext())
                {
                    // Check if there if a connection for the specified user name have ever been made
                    var existingConnection = db.Connections.Where(x => x.UserId == userId)
                        .SingleOrDefault();

                    if (existingConnection != null)
                    {
                        // If there's an old connection only the connection id and the online status are changed.
                        existingConnection.ConnectionId = Context.ConnectionId;
                        existingConnection.IsOnline = true;
                    }
                    else
                    {
                        // If not, then a new connection is created
                        db.Connections.Add(new Connection
                        {
                            ConnectionId = Context.ConnectionId,
                            ChatName = chatName,
                            UserId = userId,
                            IsOnline = true
                            
                        });
                    }

                    db.SaveChanges();
                }

                UsersOnline();

                return new { Success = true };

            }
            catch (Exception e)
            {

                return new {Success = false, ErrorMessage = e.Message};
            }
        }


        public override Task OnReconnected()
        {
            /*    var con = await  _unitOfWork.ConnectionRepository.GetConnectionId(Context.ConnectionId);

    if (con==null)
    {
        throw new Exception("Attempting to reconnect...");
    }

    con.IsOnline = true;

   await  _unitOfWork.Complete();

  await  UsersOnline();

    await   OnReconnected();*/

            using (var apdb = new ApplicationDbContext())
            {
                var con = apdb.Connections.Where(x => x.ConnectionId == Context.ConnectionId).SingleOrDefault();

                if (con == null)
                {
                    throw new Exception("An attempt to reconnect a non tracked connection id have been made.");

                }

                con.IsOnline = true;

                apdb.SaveChanges();
            }

            UsersOnline();

            return base.OnReconnected();
        }

        public override  Task OnDisconnected(bool stopCalled)
        {
            /*var con = await _unitOfWork.ConnectionRepository.GetConnectionId(Context.ConnectionId);

            if (con == null)
            {
                throw new Exception("Attempting to disconnect...");
            }


            con.IsOnline = false;

            await _unitOfWork.Complete();

            await OnDisconnected(stopCalled);*/

            using (var apdb = new ApplicationDbContext())
            {
                var con = apdb.Connections.Where(x => x.ConnectionId == Context.ConnectionId).SingleOrDefault();

                if (con == null)
                {
                    throw new Exception("An attempt to disconnect a non tracked connection id have been made.");

                }

                con.IsOnline = false;

                apdb.SaveChanges();
            }

            UsersOnline();

            return base.OnDisconnected(stopCalled);
        }
    }
}