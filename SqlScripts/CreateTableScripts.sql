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

CREATE TABLE leagues (
    id integer,
    name varchar,
    minamount bigint,
    maxamount bigint,
    iconid integer,
    createdat timestamp,
    updatedat timestamp
);

CREATE TABLE attachments (
    id integer,
    filename varchar,
    filepath varchar,
    createdat timestamp,
    updatedat timestamp
);

CREATE TABLE balancehistories (
    id integer,
    userid integer,
    earnamount bigint,
    createdat timestamp,
    updatedat timestamp
);

CREATE TABLE miners (
    id integer,
    amount bigint,
    createdat timestamp,
    updatedat timestamp
);

CREATE TABLE missions (
    id integer,
    name varchar,
    description varchar,
    url varchar,
    reward bigint,
    createdat timestamp,
    updatedat timestamp
);

CREATE TABLE missionsusers (
    id integer,
    missionid integer,
    userid integer,
    isdone boolean,
    createdat timestamp,
    updatedat timestamp
);

CREATE TABLE roadmaps (
    id integer,
    step varchar,
    isdone boolean,
    createat timestamp,
    updatedat timestamp
);

CREATE TABLE wheels (
    id integer,
    imageid integer,
    name varchar,
    price bigint,
    incomeamount bigint,
    createdat timestamp,
    updatedat timestamp
);

