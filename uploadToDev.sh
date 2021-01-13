#!/bin/sh

# This script works for my (Catalysm) personal workflow.
# It will likely not work out of the box for you but it's still included here :)

ssh 7d2d.csmm.app ./sdtdserver stop
xbuild sdtd_apimod.sln
ssh 7d2d.csmm.app rm -rf /home/catalysm/serverfiles/Mods/sdtd_apimod
scp -r bin/Mods/sdtd_apimod 7d2d.csmm.app:/home/catalysm/serverfiles/Mods
ssh 7d2d.csmm.app ./sdtdserver start