# 7D2D Websocket

This mod sends all logs from the server to a websocket.

The websocket runs on ControlPanelPort + 5 on the logs path. By default this is `ws://localhost:8085/log`

This mod requires Allocs fixes to be installed because we piggyback the auth from there.

## Authentication

The websocket uses [Basic authentication](https://developer.mozilla.org/en-US/docs/Web/HTTP/Authentication) with the configured admin tokens from Allocs Fixes. The token must have permission level 0.

