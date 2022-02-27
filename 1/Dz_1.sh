#!/bin/bash
mkdir -p ./{1..4}/{1..5} \
	&& touch -mad "2022-02-05" ./1/{1..5}/file.txt \
	&& touch -mad "2022-02-06" ./2/{1..5}/file.txt \
	&& touch -mad "2022-02-07" ./3/{1..5}/file.txt \
	&& touch -mad "2022-02-08" ./4/{1..5}/file.txt \
	&& tar -cvf archive.tar *
