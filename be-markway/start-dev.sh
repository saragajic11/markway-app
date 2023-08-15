echo "====== STARTED GENERATING ENV VARS ======"

LAN_IP_ADDRESS=$(ipconfig getifaddr en0)

# JWT_AUTHORITY=http://$LAN_IP_ADDRESS:5053/
    
echo MARKWAY_DB_USERNAME=postgres > .env.dev
echo MARKWAY_DB_PASSWORD=postgres >> .env.dev
echo JWT_AUTHORITY=http://identity-api/ >> .env.dev

echo "====== FINISHED GENERATING ENV VARS ======"

echo "====== LAUNCHING THE APPLICATION ======"
docker-compose --env-file=.env.dev up  --build
