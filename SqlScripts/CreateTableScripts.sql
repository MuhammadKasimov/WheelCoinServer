CREATE TABLE users (
    id integer,
    telegramid bigint,
    username varchar,
    firstname varchar,
    lastname varchar,
    istelegrampremium boolean,
    iscreator boolean,
    attachmentid integer,
    leagueid integer,
    wheelid integer,
    refereecode varchar,
    walletaddress varchar,
    createdat timestamp,
    updatedat timestamp
);

CREATE TABLE league (
    id integer,
    name varchar,
    minamount bigint,
    maxamount bigint,
    iconid integer,
    createdat timestamp,
    updatedat timestamp
);

CREATE TABLE attachment (
    id integer,
    filename varchar,
    filepath varchar,
    createdat timestamp,
    updatedat timestamp
);

CREATE TABLE balancehistory (
    id integer,
    userid integer,
    earnamount bigint,
    createdat timestamp,
    updatedat timestamp
);

CREATE TABLE miner (
    id integer,
    amount bigint,
    createdat timestamp,
    updatedat timestamp
);

CREATE TABLE mission (
    id integer,
    name varchar,
    description varchar,
    url varchar,
    reward bigint,
    createdat timestamp,
    updatedat timestamp
);

CREATE TABLE missionuser (
    id integer,
    missionid integer,
    userid integer,
    isdone boolean,
    createdat timestamp,
    updatedat timestamp
);

CREATE TABLE roadmap (
    id integer,
    step varchar,
    isdone boolean,
    createat timestamp,
    updatedat timestamp
);

CREATE TABLE wheel (
    id integer,
    imageid integer,
    name varchar,
    price bigint,
    incomeamount bigint,
    createdat timestamp,
    updatedat timestamp
);

