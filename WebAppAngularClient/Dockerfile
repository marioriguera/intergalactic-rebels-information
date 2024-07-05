FROM node:20.14.0-bullseye-slim

WORKDIR /project

RUN npm install -g @angular/cli

COPY angular.json package.json package-lock.json ./
RUN npm cache clean --force
RUN npm i

COPY . .

EXPOSE 4200
CMD ["npm", "start"]
