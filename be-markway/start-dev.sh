echo "====== STARTED GENERATING ENV VARS ======"

LAN_IP_ADDRESS=$(ipconfig getifaddr en0)
GRPC_USERS_SERVICE=http://$LAN_IP_ADDRESS:6287
JWT_AUTHORITY=http://$LAN_IP_ADDRESS:5053/
    
echo MARKWAY_DB_USERNAME=postgres > .env.dev
echo MARKWAY_DB_PASSWORD=postgres >> .env.dev
echo JWT_ISSUER_SIGNING_KEY=$(openssl rand -base64 32) >> .env.dev
echo JWT_AUTHORITY=http://identity-api/ >> .env.dev
echo GRPC_USERS_SERVICE=http://$LAN_IP_ADDRESS:6287 >> .env.dev
echo GRPC_NOTIFICATION_SERVICE=http://$LAN_IP_ADDRESS:8287 >> .env.dev
echo GENERATE_API=http://$LAN_IP_ADDRESS:9387/generate-pdf >> .env.dev
echo EMAILSERVER_HOST=smtp.sendgrid.net >> .env.dev
echo EMAILSERVER_PORT=587 >> .env.dev
echo EMAILSERVER_ENABLE_SSL=true >> .env.dev
echo EMAILSERVER_AUTH_MODE=login >> .env.dev
echo EMAILSERVER_USER=app@markwaylog.com >> .env.dev
echo EMAILSERVER_USERNAME=apikey >> .env.dev
echo EMAILSERVER_PASSWORD=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 >> .env.dev
echo ELASTICSEARCH_HOSTS=http://$LAN_IP_ADDRESS:9200 >> .env.dev
echo S3_ACCESS_KEY="AKIAUJRR2GDO54MPIEPC" >> .env.dev
echo S3_ACCESS_SECRET=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 >> .env.dev
echo S3_SERVICE_URL="https://s3.eu-central-1.amazonaws.com" >> .env.dev
echo S3_BUCKET=markway >> .env.dev
echo S3_PUBLIC_URL="https://markway.s3.eu-central-1.amazonaws.com" >> .env.dev
echo S3_REGION="eu-central-1" >> .env.dev

echo "====== FINISHED GENERATING ENV VARS ======"

echo "====== LAUNCHING THE APPLICATION ======"
docker-compose --env-file=.env.dev up  --build
