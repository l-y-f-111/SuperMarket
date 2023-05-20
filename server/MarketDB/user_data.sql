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
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."user" (user_id, user_pwd_hash, user_vip_level, user_vip_level_expire_time) VALUES (1, '$2y$10$AMzqLfvMheZJEjT37kz6ROX4Mw4aTq/YStREpHyot830USrG6XG8a', 3, '2026-05-19 08:53:59.315+00');
INSERT INTO public."user" (user_id, user_pwd_hash, user_vip_level, user_vip_level_expire_time) VALUES (18266868196, '$2a$11$QpXnNR0Eg9oVOrsQILGQDu8381x//UHx.HxoS9MUjTLwQbmCgs.U.', 0, '2023-05-20 11:31:01.277884+00');
INSERT INTO public."user" (user_id, user_pwd_hash, user_vip_level, user_vip_level_expire_time) VALUES (111111, '$2a$11$ksGwIzB7a3vWpLCVs1eHx.1.1M8letlEBIl48UHG9eoSQYNMBnWxu', 0, '2023-05-20 14:03:24.518+00');
INSERT INTO public."user" (user_id, user_pwd_hash, user_vip_level, user_vip_level_expire_time) VALUES (13156305862, '$2a$11$ksGwIzB7a3vWpLCVs1eHx.1.1M8letlEBIl48UHG9eoSQYNMBnWxu', 0, '2023-05-20 11:28:28.986474+00');


--
-- PostgreSQL database dump complete
--

