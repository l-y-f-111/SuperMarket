using System;
using System.Threading.Tasks;
using DbMiddlewarePostgresImpl;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SuperMarket.Container.Goods.Provider;
using SuperMarket.Container.Order.Provider;
using SuperMarket.Container.User.Provider;
using SuperMarket.Container.Vip.Provider;
using SuperMarket.Db.Goods.Operation;
using WebSocketSharp.Server;
using SuperMarket.Server.Api;
using SuperMarket.Server.Api.Goods;
using SuperMarket.Server.Api.Order;
using SuperMarket.Server.Api.User;
using MarketServerUtil;
using AlipayF2F;

Host.CreateDefaultBuilder()
    .ConfigureServices(
        (ctx, ss) => { ss.AddHostedService<Worker>(); }
    ).Build().Run();

public class Worker : BackgroundService
{
    public Worker() : base()
    {
    }

    protected override Task ExecuteAsync(CancellationToken ct)
    {
        var f2fClient = new F2FClient(
            "2021000121674567",
            "MIIEowIBAAKCAQEAuXnPMvYnNx1LhYIahlu0xRQNtaypfVzJtZnF4WVrI6Dq5quVhZgbW5GiPstMGoMkGSLDtEtPxVxJU0LXlNE4bNscuCjqFosGWb6+YSlSSsKoQOrurzCjtxQIqEAR9SMmnqHGVWOQrXXhVVU3jHA5GdP2JmCvSBCskS/tXd9JH8546+8SG4YiHTTg/ek6skmMwhXFgVcZGZHxyeJWijPI/u72nNUMSHkbZTsKglWahBJgiQcEKiYJ9Eka8YGerS8hp2Av34Lgu6kZw4TIPDfhAwCvk4yNpc/RkWypjdZb1zqHr3iwhgC6RUu/9L5rUy8aSDVfxH1GjbjaKbPCQkIKBwIDAQABAoIBACT2BThenUn6aIZeevKza76qVGET22LEDt5Fmo1kLImZE7aMEuvgd/MzfmWNFcliwNrRdraDG4506ZfSBiv91YS71WlNnfiIE+fmfwHVvjRvvh/RsWbwBnABagg9XFbBfny2OFPj13z5tMHQjZVK99YRy0eylLuDtx/nsSG30Vao82z+CIYoQO6jRGpAhgkm5A662uTYDxfDJ4J5vTyJRURF+QCqOb8qlRDL/ZV+ybDzUr0n5Qul3eP5n9q9JQd9Qnb2xKyS8t6ngXUXleSWHcbxcD8tAMLtFLYNjOHdsa4IelqrK5jM6e+Yl3EMLPfa4pXLBnKCdTmNcTpTXsVnmUECgYEA71jUCm3HZdB2DcG5UiRjmO9vWQNUv06uFB5Q6VM+gTDPPK5u4kz1ZRcmrAboDoRKubZHc+mooOk1C5wGaWrxHy4oBBSr1VIe5JKI6+5aBB+PlKEVIElwdANbU+1kPKytA5MeDHOof1AgvtheYltsLU4vXLG+DAuj98G7VweUZF8CgYEAxmFx9Drc8LKXt+tov4Ov5/OaPSPcezKUN+KV5semIdNkYtjuO1yTi73yNxevvRZXYN/efcG5/TJyx4Fyvp2y4HC6LXOoj1clX60pHxqWi1Lz04GJEfByqSgYBR0kMZjodgOgOOOuqPQFTywke/2lFUPF8tAVPyJLPp4jXVX++1kCgYBFvJTzgO7jHGz5LyOm6lFWoxTHU7AimXMhC4A5q3Z/v8/x90T5jMDHNoqe/tgoOqVnHNQO0tq+H5TEEC7SEkW09wbTwY4bdnTn1kYsr+LsZqG4BYMZSCyKsNuwRW+6OfmjG/9aU2yZw6f20yYU9Fw9ixVDpcogyld4/apu/hdfcwKBgCMc/F6OTK0N72zObiv30xrrM1G/Fzd3LGT35jCDBhTWpd4ZJ5G6QSNq64R03NZLLgwnk+oOcC0w0MAfWYADybWQPmPtJNi6RBM7QxwOSLdAZ4f4VZqnRKRMRHQjRFTDC+JXofRv2GpvRsFMvuhzbNTmuhLQYfJaz5a1xuyuXAOBAoGBAKkbeNyGMnuHxgJ+sWCI5pM4w5/w1iovWu3qIEaCAZqt5PW1OvtcsKtDbzq+gdnWrsvX0bjx4LWcADi7wYGDMEo9WxBw2745hIUw3d/wDL98RnT/pCqpOhxtqzfIl+HdUbZEO23HVBm8atHgh/0eWCoYw99z3geQMY1iTi8gbpaA",
            "./cert/appCertPublicKey_2021000121674567.crt",
            "./cert/alipayRootCert.crt",
            "./cert/alipayCertPublicKey_RSA2.crt"
        );

        var wsServer = new WebSocketServer("ws://localhost:11451");
        var orderGen = new IdGenerator(ActionType.Order);
        var GoodsGen = new IdGenerator(ActionType.Goods);
        var db = new PostgresDatabase
        (
            "postgres",
            "65a1561425f744e2b541303f628963f8",
            "localhost",
            5432,
            "super_Market"
        );
        
        IGoodsProvider GoodsProvider = null;
        IOrderProvider orderProvider = null;
        IUserProvider userProvider = null;
        IVipProvider vipProvider = null;

        var GoodsProviderF = () => GoodsProvider;
        var orderProviderF = () => orderProvider;
        var userProviderF = () => userProvider;
        var vipProviderF = () => vipProvider;
        
        GoodsProvider = new GoodsProvider(GoodsGen, db);
        orderProvider = new OrderProvider(
            userProviderF,
            GoodsProvider,
            new GoodsOperation(db),
            orderGen,
            db
        );
        userProvider = new UserProvider(orderProviderF, db);
        vipProvider = new VipProvider(db);

//Goods
        wsServer.AddWebSocketService<AddGoods>
        ("/add_goods",
            handler => handler.Set(GoodsProviderF()));
        wsServer.AddWebSocketService<DeleteGoods>
        ("/delete_goods",
            handler => handler.Set(GoodsProviderF()));
        wsServer.AddWebSocketService<GetAllGoods>
        ("/get_all_goods",
            handler => handler.Set(GoodsProviderF()));
        wsServer.AddWebSocketService<GetAllGoodsType>
        ("/get_all_goods_type",
            handler => handler.Set(GoodsProviderF()));
        wsServer.AddWebSocketService<GetGoods>
        ("/get_goods",
            handler => handler.Set(GoodsProviderF()));
        wsServer.AddWebSocketService<SearchGoods>
        ("/search_goods",
            handler => handler
                .Set(
                    GoodsProviderF()
                )
        );
        wsServer.AddWebSocketService<UpdateGoods>
        ("/update_goods",
            handler => handler.Set(GoodsProviderF()));

//Order
        wsServer.AddWebSocketService<CreateOrder>
        ("/create_order",
            handler => handler
                .Set(
                    userProviderF(),
                    GoodsProviderF(),
                    orderProviderF(),
                    f2fClient
                )
        );
        wsServer.AddWebSocketService<GetAllOrder>
        ("/get_all_order",
            handler => handler.Set(orderProviderF(), f2fClient));
        wsServer.AddWebSocketService<GetOrder>
        ("/get_order",
            handler => handler.Set(orderProviderF(), f2fClient));
        wsServer.AddWebSocketService<GetAllOrderWithUserId>
        ("/get_all_order_with_user_id",
            handler => handler.Set(userProviderF()));
        wsServer.AddWebSocketService<IsOrderIdValid>
        ("/is_order_id_valid",
            handler => handler.Set(orderProviderF()));
        wsServer.AddWebSocketService<RefundOrder>
        ("/refund_order",
            handler => handler.Set(orderProviderF(), f2fClient));
        
//User
        wsServer.AddWebSocketService<AddUser>
        ("/add_user",
            handler => handler
                .Set(
                    userProviderF(),
                    vipProviderF()
                )
        );
        wsServer.AddWebSocketService<ResetUserPwd>
        ("/reset_user_pwd",
            handler => handler.Set(userProviderF()));
        wsServer.AddWebSocketService<GetUser>
        ("/get_user",
            handler => handler.Set(userProviderF()));
        wsServer.AddWebSocketService<IsUserIdMatchPwd>
        ("/is_user_id_match_pwd",
            handler => handler.Set(userProviderF()));
        wsServer.AddWebSocketService<RefundUserVip>
        ("/refund_user_vip",
            handler => handler.Set(userProviderF()));
        wsServer.AddWebSocketService<GetUserVipLevel>
        ("/get_user_vip_level",
            handler => handler.Set(userProviderF(), vipProviderF()));
        wsServer.AddWebSocketService<UpgradeUserVip>
        ("/upgrade_user_vip",
            handler => handler
                .Set(
                    userProviderF(),
                    vipProviderF()
                )
        );

        return Task.Run(() => { wsServer.Start(); });
    }
}