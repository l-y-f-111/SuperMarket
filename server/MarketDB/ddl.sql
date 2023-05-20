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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: goods; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.goods (
    goods_id bigint,
    goods_name text,
    goods_is_ready boolean,
    goods_types text,
    goods_price double precision,
    goods_cover_img text,
    goods_preview_video_url text,
    goods_stock bigint
);


ALTER TABLE public.goods OWNER TO postgres;

--
-- Name: order; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."order" (
    order_id bigint,
    order_user_id bigint,
    order_pay_amount double precision,
    order_goods_id bigint,
    order_time timestamp with time zone,
    order_status text
);


ALTER TABLE public."order" OWNER TO postgres;

--
-- Name: user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."user" (
    user_id bigint,
    user_pwd_hash text,
    user_vip_level bigint,
    user_vip_level_expire_time timestamp with time zone
);


ALTER TABLE public."user" OWNER TO postgres;

--
-- Name: vip; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.vip (
    vip_level bigint,
    vip_discount double precision,
    vip_month_price double precision
);


ALTER TABLE public.vip OWNER TO postgres;

--
-- PostgreSQL database dump complete
--

