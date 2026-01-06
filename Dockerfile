version: '3.8'

services:
  db:
    image: postgres:16
    restart: always
    environment:
      POSTGRES_PASSWORD: Olhe8pOWWi6tnLvlKoqX
      POSTGRES_USER: graggor
      POSTGRES_DB: Huginn
    ports:
      - "5432:5432"
    volumes:
      - pgdata:/var/lib/postgresql/data

volumes:
  pgdata:
