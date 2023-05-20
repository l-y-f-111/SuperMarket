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
-- Data for Name: order; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."order" (order_id, order_user_id, order_pay_amount, order_goods_id, order_time, order_status) VALUES (1, 1, 5498, 24, '2021-05-20 10:52:20.822+00', 'paid');
INSERT INTO public."order" (order_id, order_user_id, order_pay_amount, order_goods_id, order_time, order_status) VALUES (3, 1, 47999, 20, '2023-01-20 10:47:25.485+00', 'created');
INSERT INTO public."order" (order_id, order_user_id, order_pay_amount, order_goods_id, order_time, order_status) VALUES (2, 1, 3499, 16, '2023-05-20 10:52:18.79+00', 'paid');
INSERT INTO public."order" (order_id, order_user_id, order_pay_amount, order_goods_id, order_time, order_status) VALUES (6, 1, 25499, 7, '2023-05-20 07:55:58.07+00', 'paid');
INSERT INTO public."order" (order_id, order_user_id, order_pay_amount, order_goods_id, order_time, order_status) VALUES (10, 1, 1599, 5, '2023-05-20 10:56:07.304+00', 'paid');
INSERT INTO public."order" (order_id, order_user_id, order_pay_amount, order_goods_id, order_time, order_status) VALUES (8, 1, 11999, 9, '2023-05-20 10:56:06.172+00', 'paid');
INSERT INTO public."order" (order_id, order_user_id, order_pay_amount, order_goods_id, order_time, order_status) VALUES (4, 1, 7499, 10, '2023-05-20 10:56:05.171+00', 'refunded');
INSERT INTO public."order" (order_id, order_user_id, order_pay_amount, order_goods_id, order_time, order_status) VALUES (7, 1, 11598, 3, '2023-05-20 10:56:05.679+00', 'paid');
INSERT INTO public."order" (order_id, order_user_id, order_pay_amount, order_goods_id, order_time, order_status) VALUES (5, 1, 18999, 23, '2023-05-20 10:56:04.554+00', 'created');
INSERT INTO public."order" (order_id, order_user_id, order_pay_amount, order_goods_id, order_time, order_status) VALUES (9, 1, 9999, 18, '2023-07-20 10:56:02.123+00', 'paid');
INSERT INTO public."order" (order_id, order_user_id, order_pay_amount, order_goods_id, order_time, order_status) VALUES (45674480136101888, 18266868196, 9999, 8, '2023-05-20 11:36:18.622053+00', 'created');


--
-- PostgreSQL database dump complete
--

