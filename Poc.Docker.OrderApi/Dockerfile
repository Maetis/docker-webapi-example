FROM mono:4.2.1.102

EXPOSE 8080

RUN mkdir -p /usr/src/app/webapi
WORKDIR /usr/src/app/webapi

COPY ./bin/release /usr/src/app/webapi

CMD ["mono", "./Poc.Docker.OrderApi.exe"]