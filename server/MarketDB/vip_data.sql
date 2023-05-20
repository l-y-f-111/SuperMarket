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
-- Data for Name: vip; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.vip (vip_level, vip_discount, vip_month_price) VALUES (0, 1, 1);
INSERT INTO public.vip (vip_level, vip_discount, vip_month_price) VALUES (1, 0.9, 2);
INSERT INTO public.vip (vip_level, vip_discount, vip_month_price) VALUES (3, 0.8, 3);


--
-- PostgreSQL database dump complete
--

