<p align="center">
    <img src="/ReadMe/Logo.PNG" alt="robosapiens logo" width="72" height="72">
</p>

<h3 align="center">RoboSapiens</h3>

<p align="center">
  Powerful and Intuitive Channel for faster and effective business comunications.
  <br>
  <a href="#">Quick Start</a>
  ·
  <a href="#">Request feature</a>
  ·
  <a href="https://themes.getbootstrap.com/">Other</a>
  ·
  <a href="https://blog.getbootstrap.com/">Other</a>
</p>

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)

------
![](/ReadMe/Pitch%20(bozza).jpg)


------



## The Problem 

Nearly every business flow that makes use of phone calls as their main communication channel suffers from the following problems:

![](/ReadMe/Pitch (bozza) (1).jpg)

## Our Vision

Our Application makes possible to handle customer comunications within the same application regardless the comunication channel they chose to use.

This approach has the following advantages:

- The conversation data can be analyzed by AI and can build a big datasource that together with ML algoriths is very likely to discover useful paths to improve your workflow or your business in general.

- The idle time of the operators will not be wasted as in the phone communication but by switching conversations the operators can handle several conversation simultaneously.

- The Application provides message autocomplition and most answers that most likely the operator is going to give.

- The Messages in the chat will be analyzed to find out the state of mind of the customers in the conversation, making possible to exactly know how the operators are performing.

![](/ReadMe/Slide2.PNG)

![](/ReadMe/Slide3.PNG)

![](/ReadMe/Slide4.PNG)

## Quick start

Several quick start options are available:

- [Download](https://github.com/) or Clone the Web App repo: `git clone https://github.com/simonedemuro/RoboSapiens.git`

- [Download](https://github.com/) or Clone the Python API repo: `git clone https://github.com/Walid/RoboSapiensAPI.git`

- Restore the SQL Server  [database](https://linkAlFileDotBak) in a local istance: 

  ```sql
  RESTORE DATABASE RoboSapiens
  FROM DISK = 'C:\<yourPath>/RoboSapiensBk.bak'
  WITH REPLACE
  ```

- Create a [Telegram](http://createTelegramBot) Bot and replace the token inside appsettings.json:

- `  "BotConfiguration": {
      "BotToken": "844501739:AAEAU93gOtAx2fsHrUTW9VpCa8UePwLwNho",
      "Socks5Host": ""
    }` 

- Run ngrok: `ngrok.exe http 8443 -host-header="localhost:8443"`

Read the [Getting started page](https://getbootstrap.com/docs/4.3/getting-started/introduction/) for information on the framework contents, templates and examples, and more.

