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

INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (45574120281214976, '商品名', false, 'A', 0, '图片', '介绍视频URL', NULL);
INSERT INTO public.goods (goods_id, goods_name, goods_is_ready, goods_types, goods_price, goods_cover_img, goods_preview_video_url, goods_stock) VALUES (45574126165823488, '商品名1', false, '', 0, '图片', '介绍视频URL', NULL);


--
-- Data for Name: order; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."user" (user_id, user_pwd_hash, user_vip_level, user_vip_level_expire_time) VALUES (1, '$2y$10$AMzqLfvMheZJEjT37kz6ROX4Mw4aTq/YStREpHyot830USrG6XG8a', 3, '2026-05-19 08:53:59.315+00');


--
-- Data for Name: vip; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.vip (vip_level, vip_discount, vip_month_price) VALUES (3, 1, 1);


--
-- PostgreSQL database dump complete
--

