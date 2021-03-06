﻿

using Microsoft.AspNet.SignalR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Messag.Logger;
using Messag.Utility.Config;
using Megadotnet.MessageMQ.Adapter;
using BusniessEntities.Models;
using WebAuth;

namespace WebAuth
{
    /// <summary>
    /// MQHubsConfig
    /// </summary>
    public class MQHubsConfig
    {
        /// <summary>
        /// ILogger
        /// </summary>
        private static ILogger log = new Logger("MQHubsConfig");

        /// <summary>
        /// Registers the mq listen and hubs.
        /// </summary>
        public static void RegisterMQListenAndHubs()
        {
            string queueDestname = MQConfig.QueueDestination;
            Task.Factory.StartNew(() =>
            {

#if DEBUG
                queueDestname = MQConfig.QueueDestination;
#endif
                var activemq = ActiveMQListenAdapter<PushMsg>.Instance(MQConfig.MQIpAddress, queueDestname);

                activemq.MQListener += m =>
                {
                    CallClientMethod(m);
                };

                activemq.ReceviceListener<PushMsg>();
            });

        }

        /// <summary>
        /// Calls the client method.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <exception cref="System.ArgumentNullException">User list should not be null</exception>
        private static void CallClientMethod(PushMsg m)
        {
            if (m.Users == null)
                throw new ArgumentNullException("User list should not be null");

            var userAccounts = m.Users.ToArray();

            log.InfoFormat("从MQ收到消息{0}", m.MSGCONTENT);
            //GlobalHost.ConnectionManager.GetHubContext<FeedHub>().Clients.All.receive(m);
            //push via 
            GlobalHost.ConnectionManager.GetHubContext<FeedHub>().Clients.Users(userAccounts).receive(m);

        }
    }
}