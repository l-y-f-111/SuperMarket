import {createRouter, createWebHistory} from "vue-router"

import Home from "@/components/Home.vue"
import Login from "@/components/Login.vue"
import Search from "@/components/Search.vue"
import Booking from "@/components/booking/Booking.vue"
import Register from "@/components/Register.vue"
import UserInfo from "@/components/UserInfo.vue"
import ResetPwd from "@/components/ResetPwd.vue"
import PaySuccess from "@/components/PaySuccess.vue"
import UpgradeVip from "@/components/UpgradeVip.vue"
import GoodsEditor from "@/components/goods/GoodsEditor.vue"
import RecentOrders from "@/components/order/RencentOrders.vue"
import GoodsManagement from "@/components/goods/GoodsManagement.vue"

export default createRouter({
    scrollBehavior: () => ({
        top: 0,
        behavior: 'smooth'
    }),
    history: createWebHistory(),
    routes: [
        {
            path: '/',
            component: Home,
            props: {}
        },
        {
            path: '/login',
            component: Login,
            props: {}
        },
        {
            path: '/register',
            component: Register,
            props: {}
        },
        {
            path: '/search',
            component: Search,
            props: {}
        },
        {
            path: '/booking/:goods_id',
            component: Booking,
            props: r => ({
                goodsId: BigInt(r.params.goods_id.toString())
            })
        },
        {
            path: '/pay_success/:payment_id/:alipay_qrcode_path',
            component: PaySuccess,
            props: r => ({
                payment_id: BigInt(r.params.payment_id.toString()),
                alipay_qrcode_path: r.params.alipay_qrcode_path
            })
        },
        {
            path: '/goods_management',
            component: GoodsManagement,
            props: {}
        },
        {
            path: '/goods_editor/create',
            component: GoodsEditor,
            props: {
                goods_id: 0n,
                create_goods: true
            }
        },
        {
            path: '/goods_editor/:goods_id',
            component: GoodsEditor,
            props: r => ({
                goods_id: BigInt(r.params.goods_id.toString()),
                create_goods: false
            })
        },
        {
            path: '/user_info/:user_id',
            component: UserInfo,
            props: r => ({
                user_id: BigInt(r.params.user_id.toString())
            })
        },
        {
            path: '/reset_pwd/:user_id',
            component: ResetPwd,
            props: r => ({
                user_id: BigInt(r.params.user_id.toString())
            })
        },
        {
            path: '/upgrade_vip/:user_id',
            component: UpgradeVip,
            props: r => ({
                user_id: BigInt(r.params.user_id.toString())
            })
        },
        {
            path: '/recent_orders/:user_id',
            component: RecentOrders,
            props: r => ({
                user_id: BigInt(r.params.user_id.toString())
            })
        },
    ]
})
