#!/bin/sh

ssh 7d2d.csmm.app ./sdtdserver stop
xbuild sdtd_apimod.sln
scp -r bin/Mods/sdtd_apimod 7d2d.csmm.app:/home/catalysm/serverfiles/Mods
ssh 7d2d.csmm.app ./sdtdserver start