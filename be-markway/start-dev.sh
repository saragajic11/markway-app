echo "====== STARTED GENERATING ENV VARS ======"

LAN_IP_ADDRESS=$(ipconfig getifaddr en0)
GRPC_USERS_SERVICE=http://$LAN_IP_ADDRESS:6287
JWT_AUTHORITY=http://$LAN_IP_ADDRESS:5053/
    
echo MARKWAY_DB_USERNAME=postgres > .env.dev
echo MARKWAY_DB_PASSWORD=postgres >> .env.dev
echo JWT_ISSUER_SIGNING_KEY=$(openssl rand -base64 32) >> .env.dev
echo JWT_AUTHORITY=http://identity-api/ >> .env.dev
echo GRPC_USERS_SERVICE=http://$LAN_IP_ADDRESS:6287 >> .env.dev

echo "====== FINISHED GENERATING ENV VARS ======"

echo "====== LAUNCHING THE APPLICATION ======"
docker-compose --env-file=.env.dev up  --build
