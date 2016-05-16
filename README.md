# Mana
Mana is a virtual manager. It ensures the execution and the follow-up of business processes over a long period of time. This is a demo application that is built with [Windows Workflow Foundation 4.5](https://msdn.microsoft.com/en-us/library/ee342461.aspx) (WF). It is based on BPM principles: modeling, automation, execution, control, measurement and optimization of business activity flows.

Theory about Workflow Foundation is covered very well in many resources and books. I decided to write simple but sufficient Proof Of Concept (POC) application to show how these features are useful in a real business context. I hope my attempt will benefit as much people as possible.

Mana is composed of:
 - A Workflow designer to model Business Processes.
 - A Workflow runner that allow to execute processes. These processes can be interrupted or woken up following the requirements defined during their modeling (see [Why Workflows?](https://github.com/uni1PBN/Mana/wiki/Why-Workflows) in the Wiki).

## Getting Started
In order to run this application, you must first setup the database and the Entity Framework data model (see Wiki - [Setup database](https://github.com/uni1PBN/Mana/wiki/Setup-Database)).
