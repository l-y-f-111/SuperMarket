--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Data for Name: goods; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (8, '外星人x14', true, '高刷$高端$4090$轻薄本', 9999, 'https://img12.360buyimg.com/n7/jfs/t1/134008/17/32775/46328/6465fc40Faf02b46a/70885259bdc21018.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 435);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (45574120281214976, '锐龙R5 5600', true, 'amd$cpu', 1122, 'https://g-search3.alicdn.com/img/bao/uploaded/i4/i1/4184230178/O1CN01SLWAFW1DBZI8FUOZt_!!0-item_pic.jpg_580x580q90.jpg_.webp', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 133);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (3, '七彩虹4070', false, '显卡$机械$高端$4060', 11598, 'https://img13.360buyimg.com/n7/jfs/t1/201760/20/33069/150478/6446422dF5c3f7a44/113b61b72f05c2e3.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 32);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (12, 'p50', true, '显卡$电脑$机械$高频$高清', 5500, 'https://img13.360buyimg.com/n7/jfs/t1/106565/32/39546/102602/643f9d21F819e66bf/45fc4101bf02bc3d.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 54);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (11, 'r9000', true, '显卡$电脑$4070ti$amd', 8999, 'https://img14.360buyimg.com/n7/jfs/t1/56197/10/21834/97203/6438ee4aF95d417f6/6c26441058104899.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 34);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (9, '幻16', true, '性价比$轻薄本$败家之眼$ROG', 11999, 'https://img13.360buyimg.com/n7/jfs/t1/201760/20/33069/150478/6446422dF5c3f7a44/113b61b72f05c2e3.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 53);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (1, 'p60', true, 'huawei$高端$618', 4388, 'https://img10.360buyimg.com/n7/jfs/t1/200776/23/17853/37628/641d47e4F962e0870/ef3afe0a206bb667.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 4);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (4, '酷睿i5-13400f', false, '显卡$电脑$机械$cpu', 3500, 'https://img10.360buyimg.com/n7/jfs/t1/101776/8/32391/71048/63ae90daFa678bf50/423b124c0e641e88.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 54);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (6, 'AMD 5600G', false, '显卡$amd$机械$芯片', 3199, 'https://img12.360buyimg.com/n7/jfs/t1/115929/1/31865/71742/6440e5caFc7d3a830/957087e6c92c8636.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 23);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (19, 'xiaomi13', true, '小米$手机$高端$折叠屏$徕卡', 4599, 'https://img14.360buyimg.com/n7/jfs/t1/66577/31/20144/29623/6465c73cFf9e1daa8/d36568e62542fdd9.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 432);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (16, 'k50pro', true, '降价&新品$高通', 3499, 'https://img14.360buyimg.com/n7/jfs/t1/35610/13/18550/76217/6399aff5Ef2682b60/ebdd9c219297fc97.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 324);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (10, 'y7000p', true, '联想$新品$爆款$2021', 7499, 'https://img14.360buyimg.com/n7/jfs/t1/219282/7/29458/68988/6446255cF68c6eca8/0efcd256c7d6cb61.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 5345);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (18, 'iqoo neo8', true, '手机$日用$618$折扣', 9999, 'https://img10.360buyimg.com/n7/jfs/t1/180547/7/33244/82121/645d9adbF3be5a993/95491848e6262e9d.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 32);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (2, 'hhkb', false, '日本$键盘$机械$静电容$编程', 3799, 'https://img12.360buyimg.com/n7/jfs/t1/100934/28/39482/68454/645de890Fe7a1cd61/e30f80d46aee8623.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 55);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (15, 'k60pro', true, '便宜$手机$红米$性价比', 3599, 'https://img13.360buyimg.com/n7/jfs/t1/94263/6/37742/43778/63dcc955F444809f8/e001e09382c4bbb8.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 2);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (14, 'r9000p', true, '显卡$电脑$4060$高刷', 9999, 'https://img11.360buyimg.com/n7/jfs/t1/212773/39/12539/111441/620a21deEfd97e21e/9854eed752de08e5.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 4);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (13, 'dior', true, '高端$高奢$奢侈品', 544, 'https://img14.360buyimg.com/n7/jfs/t1/91375/18/38395/62515/644092d1F8cb3f4e0/e6d6ab8f601cfd07.png', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 2);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (24, '大疆 如影3pro', true, '大疆$稳定器$大师镜头', 5498, 'https://g-search2.alicdn.com/img/bao/uploaded/i4/i3/1773095659/O1CN01XoNkpf1rfsAkckR9N_!!0-item_pic.jpg_580x580Q90.jpg_.webp', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 23);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (21, '哈苏x2d', true, '相机$中画幅$入门$一亿像素', 88799, 'https://g-search1.alicdn.com/img/bao/uploaded/i4/imgextra/i2/26934285/O1CN01EzN1N11hWZwzVU41U_!!0-saturn_solar.jpg_580x580Q90.jpg_.webp', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 32);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (20, 'nikonz8', true, '相机$全画幅$618$热卖$新款', 47999, 'https://img11.360buyimg.com/n7/jfs/t1/110471/15/36056/83851/645d376aF246a9fe8/568658e619424035.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 432);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (7, 'sony a7r5', true, '对焦$性价比$a7m4$新款$热卖', 25499, 'https://img10.360buyimg.com/n7/jfs/t1/90060/8/32780/201732/645c8b05F389fdcfb/b9c89b8f5eff1c3d.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 34);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (17, '佳能 r62', true, '相机$佳能$高画质$百亿补贴', 19999, 'https://img12.360buyimg.com/n7/jfs/t1/67193/38/24340/59354/6464ab87F08ed86eb/09a0b60cb6982f24.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 324);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (26, 'creed 银色山泉', true, '香水$小众$夏天$中性香$柑橘 ', 1899, 'https://g-search1.alicdn.com/img/bao/uploaded/i4/imgextrahttps://img.alicdn.com/imgextra/i3/2213053752083/O1CN01nunMwy1RG3q4vsqHa_!!2213053752083-0-alimamacc.jpg_580x580Q90.jpg_.webp', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 234);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (23, '大疆 御3pro', true, '大疆$无人机$新品$变焦$大师镜头', 18999, 'https://g-search1.alicdn.com/img/bao/uploaded/i4/i4/1773095659/O1CN01F8n1IR1rfsAdq8SS6_!!0-item_pic.jpg_580x580Q90.jpg_.webp', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 543);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (28, '大疆action3', true, '大疆$运动相机$画质好$618$性价比', 3199, 'https://g-search1.alicdn.com/img/bao/uploaded/i4/imgextra/i2/117150821/O1CN0183DN8S1Hw3ygtyGrP_!!0-saturn_solar.jpg_580x580Q90.jpg_.webp', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 32);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (22, '徕卡q2', true, '相机$全画幅$入门$拍照', 48900, 'https://g-search1.alicdn.com/img/bao/uploaded/i4/imgextra/i4/115090871/O1CN01QJvvU21IIxkgr8m7M_!!0-saturn_solar.jpg_580x580Q90.jpg_.webp', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 43443);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (27, '蝴蝶忍手办', true, '手办$鬼灭之刃$眼镜厂$百亿补贴', 899, 'https://g-search1.alicdn.com/img/bao/uploaded/i4/imgextra/i2/507250175/O1CN014XNzBO1DAC5WPdo3O_!!0-saturn_solar.jpg_580x580Q90.jpg_.webp', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 23);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (5, '阿米洛嫦娥', true, '阿米洛$中国风$嫦娥$静电容', 1599, 'https://gw.alicdn.com/imgextra/O1CN01fTul9e1HrU36pvzDs_!!2861950811-0-picasso.jpg', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 5);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (29, '低卡辣椒酱', true, 'R哥$减肥$好吃', 14.9, 'https://gw.alicdn.com/bao/uploaded/i4/2212012328361/O1CN01pIdqfI2BdOJM5Dvuc_!!0-item_pic.jpg_300x300q90.jpg_.webp', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 34);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (30, '符华手办', true, '崩坏3$符华$手办$官方$原批', 899, 'https://g-search1.alicdn.com/img/bao/uploaded/i4/i3/3249253975/O1CN01GFIjv51fEb9PYI1GN_!!0-item_pic.jpg_580x580Q90.jpg_.webp', 'https://www.bilibili.com/video/BV1da4y1g77S?t=22.9', 0);


--
-- PostgreSQL database dump complete
--
