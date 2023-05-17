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
-- Name: default_schema; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA default_schema;


ALTER SCHEMA default_schema OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: cinema; Type: TABLE; Schema: default_schema; Owner: postgres
--

CREATE TABLE default_schema.cinema (
    cinema_id bigint,
    cinema_name text
);


ALTER TABLE default_schema.cinema OWNER TO postgres;

--
-- Name: film; Type: TABLE; Schema: default_schema; Owner: postgres
--

CREATE TABLE default_schema.film (
    film_id bigint,
    film_name text,
    film_online_time timestamp with time zone,
    film_is_preorder boolean,
    film_types text,
    film_price double precision,
    film_actors text,
    film_cover_url text,
    film_preview_video_url text
);


ALTER TABLE default_schema.film OWNER TO postgres;

--
-- Name: order; Type: TABLE; Schema: default_schema; Owner: postgres
--

CREATE TABLE default_schema."order" (
    order_id bigint,
    order_user_id bigint,
    order_pay_amount double precision,
    order_film_id bigint,
    order_cinema_id bigint,
    order_schedule_id bigint,
    order_cinema_seat text,
    order_time timestamp with time zone,
    order_status text
);


ALTER TABLE default_schema."order" OWNER TO postgres;

--
-- Name: schedule; Type: TABLE; Schema: default_schema; Owner: postgres
--

CREATE TABLE default_schema.schedule (
    schedule_cinema_id bigint,
    schedule_film_id bigint,
    schedule_start_time timestamp with time zone,
    schedule_end_time timestamp with time zone,
    schedule_id bigint
);


ALTER TABLE default_schema.schedule OWNER TO postgres;

--
-- Name: user; Type: TABLE; Schema: default_schema; Owner: postgres
--

CREATE TABLE default_schema."user" (
    user_id bigint,
    user_pwd_hash text,
    user_vip_level bigint,
    user_vip_level_expire_time timestamp with time zone
);


ALTER TABLE default_schema."user" OWNER TO postgres;

--
-- Name: vip; Type: TABLE; Schema: default_schema; Owner: postgres
--

CREATE TABLE default_schema.vip (
    vip_level bigint,
    vip_discount double precision,
    vip_month_price double precision
);


ALTER TABLE default_schema.vip OWNER TO postgres;

--
-- Name: goods; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.goods (
    goods_id bigint,
    goods_name text,
    goods_is_preorder boolean,
    goods_types text,
    goods_price double precision,
    goods_cover_url text,
    goods_preview_video_url text,
    goods_cover_img bytea
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
-- Data for Name: cinema; Type: TABLE DATA; Schema: default_schema; Owner: postgres
--



--
-- Data for Name: film; Type: TABLE DATA; Schema: default_schema; Owner: postgres
--



--
-- Data for Name: order; Type: TABLE DATA; Schema: default_schema; Owner: postgres
--



--
-- Data for Name: schedule; Type: TABLE DATA; Schema: default_schema; Owner: postgres
--



--
-- Data for Name: user; Type: TABLE DATA; Schema: default_schema; Owner: postgres
--



--
-- Data for Name: vip; Type: TABLE DATA; Schema: default_schema; Owner: postgres
--



--
-- Data for Name: goods; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: order; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- PostgreSQL database dump complete
--

