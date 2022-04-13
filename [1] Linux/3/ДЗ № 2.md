# ДЗ № 2

Код start-pinger.sh:

```
#!/bin/bash

nohup sudo -u pinger /usr/local/bin/pinger.sh &>> /var/log/pinger/pinger.log & # запускаем демон от пользака pinger, пишем логи ошибок и обычный вывод в pinger.log
echo $! > /run/pinger/pinger.pid # пишем логи в pinger.pid
```

Код скрипта-демона pinger.sh:
```
#!/bin/bash

while true; do
	date
	sleep 1
done
```
Для того, чтобы остановить процесс демона, используем скрипт stop-pinger.sh
```
#!/bin/bash

sudo pkill -F /run/pinger/pinger.pid \ # убиваем процесс с PID в файле pinger.pid
rm -f /run/pinger/pinger.pid # удаляем файл(не обязательно, т.к в pinger.sh команда постоянно перезаписывает значение файла pinger.pid)
```
Для того, чтобы логи чистились, используем конфиг logrotate в /etc/logrotate.d/pinger.conf
```
/var/log/pinger/pinger.log { # полный путь до лог файла
daily # logrotate запускается каждый день
rotate 2 # указываем кол-во старых логов, которые необходимо хранить
size 50M # размер лога, когда он будет перемещен
compress # сжимаем логи
delaycompress #сжимаем все кроме предпоследней, последней записи в лог
}

```
Для запуска как init process необходимо добавить кофиг в /etc/systemd/system/pinger.service
```
[Unit]
Description=My service pinger
After=network.target network-online.target remote-fs.target

[Service]
Type=forking
User=pinger # юзер, от которого будет совершаться запуск
Group=pinger # группа, от которой будет совершаться запуск
EnvironmentFile=-/etc/default/pinger 
ExecStart=/usr/local/bin/start-pinger.sh # Запускатор демона
ExecStop=/usr/local/bin/stop-pinger.sh # "убийца" демона
LimitNOFILE=65536

[Install]
WantedBy=multi-user.target
```
Все готово, можно запускать:

![](https://i.imgur.com/VPvw6gE.png)

1) systemctl daemon-reload - для принятия изменений в конфигах systemd;
2) systemctl start pinger.service && systemctl status pinger.service - статус показывает, что демон активен;
3) Смотрим логи, логи сыпятся без остановки;
4) PID процесса успешно записан и совпадает с цифров в выводе команды status;
5) Для остановки используем команду systemctl stop pinger.service

![](https://i.imgur.com/aSYIeOv.png)

Процесс убит, сервис inactive. Логи перестали сыпаться, PID файл удален.

Для архивации всех необходимых артифактов используем tar:
1) tar -cpzf archive.tgz /usr/local/bin/ /etc/systemd/system/pinger.service /var/log/pinger/pinger.log /run/pinger/ /etc/logrotate.d/pinger.conf - архивируем;
2) scp pinger@178.154.200.104:/tmp/1/archive.tgz . - перемещаем с виртуальной машины на хост архив;
3) tar -tvf archive.tgz - на хосте проверяем, что все права сохранились.

![](https://i.imgur.com/1Sesdjh.png)
