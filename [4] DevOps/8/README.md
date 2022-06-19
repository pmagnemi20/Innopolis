#  4.9 Централизованный сбор метрик Prometheus

1. Скачиваем с гитхаба ласт версию прометеуса
2. `wget https://github.com/prometheus/prometheus/releases/download/v2.36.1/prometheus-2.36.1.linux-amd64.tar.gz`
3. ![](https://i.imgur.com/G0RnQMv.png)

Меняю конфиг prometheus.yml, а именно блок в job prometheus, targer на localhost:9100, поскольку node_exporter по дефолту работает на 9100 порту
![](https://i.imgur.com/8x5gQj7.png)

4. Качаем node_exporter
```
wget https://github.com/prometheus/node_exporter/releases/download/v1.3.1/node_exporter-1.3.1.linux-amd64.tar.gz
```
и запускаем ./node_exporter
5. Запустив, через браузер можно увидеть метрики
![](https://i.imgur.com/VEQYAdh.png)
6. Далее запускаем прометеус
```
./prometheus --config.file=prometheus.yml
```
![](https://i.imgur.com/8CdpATD.png)
7. ![](https://i.imgur.com/rL94ygE.png)
В таргетах можно увидеть наш инстанс, где висит экспортер
8. Далее нужно установить экспортер на второй тачке, и добавить в таргеты прометеуса еще одну тачку
9. Метрики со второй тачки 
![](https://i.imgur.com/5fZPiPS.png)
10. Поменял конфиг и запустил снова прометеус
![](https://i.imgur.com/KflaxAm.png)
![](https://i.imgur.com/hEzWCp7.png)

11. node_filesystem_avail_bytes /1024/1024 Просмотр загруженности диска.
![](https://i.imgur.com/QV4S02c.png)
Метрики с локалхоста:
![](https://i.imgur.com/ZDAuIe6.png)
Метрики с 51.250.77.238:9100:
![](https://i.imgur.com/0t8MtVS.png)
В первом случае в корне свободно 8.1G, во втором 26G. Прометеус показывает те же показатели
![](https://i.imgur.com/PhbRwnL.png)
Все сходится