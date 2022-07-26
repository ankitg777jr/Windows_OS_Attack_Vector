# Windows OS Attack Vector
Windows OS Attack Vector, Discord Based Application to be used as Remote Access Tool for getting the access and persistence in a remote system developed in C#.
This is a Major project for the fulfillment of Major II in Semmester 8 for the students of the B.Tech Computer Science and Engineering Branch of [UPES](https://www.upes.ac.in) University of Petroleum and Energy Studies.


## Table of contents

- [Overview](#overview)
- [Technologies Used](#technologies_used)
- [Features](#features)
- [People Behind](#people_behind)
- [References](#references)


## Overview <a name='overview'></a>
The purpose of doing this project is to create a fully undetectable payload that is able to bypass all the Antivirus solutions installed on a system or perhaps the systems own malware defense like windows defender in windows Operating System. With the help of this payload, it would be easy to reside in a system fully undetected even after the system is fully secured with the various Anti-Malware Programs and the defense strategies. The target OS would be Windows as it’s the most widely used Operating System in the Present scenario. Our project aims to make the payload to stay persistent even on a Patched system.

![WOSAV](https://user-images.githubusercontent.com/46749964/180976100-10c1b732-935e-4718-98a1-fc0875f2487c.png)


## Technologies Used <a name='technologies_used'></a>

* C# Programing Language
* Discord Server
* Virtual Machine
* Windows (10) OS
* Windows Platform


## Features <a name='features'></a>

* get : Get username, machine name, IP address, IP location, unique ID of all infected machines.
* getsc {unique_id} : Get screenshot of specified machine.
* getcam {unique_id} : Get snapshot from all video sources on specified machine.
* getfile {unique_id} {file_path} : Upload file located in {file_path} on specified machine to Discord.
* getav {unique_id} : Get all antivirus products installed on specified machine.
* getlogins {unique_id} : Get saved Chromium-based browser passwords on specified machine.
* getcookies {unique_id} : Get saved Chromium-based browser cookies on specified machine.
* shell {unique_id} : Start remote command prompt session on specified machine.
* powershell {unique_id} : Start remote PowerShell session on specified machine (automatically bypasses AMSI).
* execute {unique_id} {command} : Execute command on specified machine.
* startkeylogger {unique_id} : Start keylogger on specified machine.
* stopkeylogger {unique_id} : Stop keylogger on specified machine.
* getkeylog {unique_id} : Get logged keys on specified machine.
* startddos {website_url} : Make all infected machines send GET requests to specified URL.
* stopddos : Make all infected machines stop sending GET requests.
* uninfect {unique_id} : Uninfect specified machine.

![COSS1](https://user-images.githubusercontent.com/46749964/180978952-c544c42d-a22d-4b54-8bf4-dce9810f148b.png)

![COSS2](https://user-images.githubusercontent.com/46749964/180980253-285d6cfe-d101-4911-bb44-ecd9926c20d9.png)


## People Behind The Project<a name='people_behind'></a>

![PBTP](https://user-images.githubusercontent.com/46749964/180982275-df4e667d-0b82-4cef-b25e-58468040d258.png)


## References <a name='references'></a>

* [Rapid7](https://www.rapid7.com/)
* [Stack Overflow](https://stackoverflow.com/)
