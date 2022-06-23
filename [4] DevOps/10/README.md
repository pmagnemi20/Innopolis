# 4.11 Централизованная обработка логов Loki, ELK 

Для начала, на двух тачках я поднял свое приложение, все через докер композ, для этого у меня есть [ветка с пайплайном](https://gitlab.com/xokage/exchangeservice/-/tree/loki):
1.
![](https://i.imgur.com/Lzrcbqg.png)
2.
![](https://i.imgur.com/uF3uNU7.png)
Запросы логируются внутри контейнера:
![](https://i.imgur.com/5Al1bjX.png)

Далее с прошлого дз у меня развернута графана на тачке 
http://51.250.77.238:3000

![](https://i.imgur.com/5gnJf3m.png)

Ставлю на тачку с графаной Loki через контейнер:
```
wget https://raw.githubusercontent.com/grafana/loki/v2.5.0/cmd/loki/loki-local-config.yaml -O loki-config.yaml
docker run --name loki -d -v $(pwd):/mnt/config -p 3100:3100 grafana/loki:2.5.0 -config.file=/mnt/config/loki-config.yaml
```
![](https://i.imgur.com/NI9BRBU.png)
Все работает
Далее нужно поставить промтейл:
```
wget https://raw.githubusercontent.com/grafana/loki/v2.5.0/clients/cmd/promtail/promtail-docker-config.yaml -O promtail-config.yaml

docker run --name promtail --rm -d -v $(pwd):/mnt/config -v /var/log:/var/log -v  /var/lib/docker/containers/:/var/lib/docker/containers/ --link loki grafana/promtail:2.5.0 -config.file=/mnt/config/promtail-config.yaml
```
Для того чтобы собирались логи с контейнеров, меняем конфиг промтейла:
![](https://i.imgur.com/qAux6hy.png)
Здесь используется алиас loki, поскольку запуск локи и промтейла на одной тачке.
На другой машине качаем конфиг промтейла, меняем его и запускаем в докере:
```
wget https://raw.githubusercontent.com/grafana/loki/v2.5.0/clients/cmd/promtail/promtail-docker-config.yaml -O promtail-config.yaml

docker run --name promtail --rm -d -v $(pwd):/mnt/config -v /var/log:/var/log -v  /var/lib/docker/containers/:/var/lib/docker/containers/ grafana/promtail:2.5.0 -config.file=/mnt/config/promtail-config.yaml
```
В графане настраиваем data source from Loki:
![](https://i.imgur.com/urJNWqm.png)

Далее можно искать логи:
Первая тачка
![](https://i.imgur.com/qWbSVLx.png)
![](https://i.imgur.com/2Fp2NW8.png)
Последние логи выглядят так, в графане:
![](https://i.imgur.com/7ScVFNS.png)
Выбрал в лейбле filename тот самый контейнер, вижу те же логи, что последние через docker logs
Аналогичная история со второй тачкой:
![](https://i.imgur.com/tzmtgpB.png)
![](https://i.imgur.com/bG45Idc.png)
Последние логи выглядят так, в графане:
![](https://i.imgur.com/weAjNjY.png)
Выбрал в лейбле filename тот самый контейнер, вижу те же логи, что последние через docker logs

