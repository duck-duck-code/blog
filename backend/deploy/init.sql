create database dev with owner postgres;
create user app_user with password 'secret';
grant connect on dev to app_user;

\connect dev

create schema blog;
grant usage on blog to app_user;

alter default privileges in schema blog
grant all on table to app_user;

alter default privileges in schema blog
grant all on sequences to app_user;

alter default privileges in schema blog
grant all on functions to app_user;

alter default privileges in schema blog
grant all on types to app_user;