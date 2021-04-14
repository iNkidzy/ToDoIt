pipeline {
    agent any
    triggers{
        pollSCM("H/5 * * * *")
    }
    stages {
        stage("Build Web") {
            steps {
               //echo "===== OPTIONAL: Will build the website (if needed) ====="
                sh "dotnet build src/WebApi/WebApi.csproj"
            }
        }
        stage("Build API") {
            steps {
                sh "dotnet build src/API/API.csproj"
            }
        }
        stage("Build database") {
            steps {
                echo "===== OPTIONAL: Will build the database (if using a state-based approach)Using Flyway so No ====="
            }
        }
        stage("Test API") {
            steps {
              //  echo "===== REQUIRED: Will execute unit tests of the API project ====="
              sh "dotnet test test/UnitTest UnitTest.csproj"
            }
        }
        stage("Deliver Web") {
            steps {
               // echo "===== REQUIRED: Will deliver the website to Docker Hub ====="
                sh "docker build ./src/WebApi -t nadiamiteva/mysqlserver-db"
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'DockerHub', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
				{
					sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
				}
                sh "docker push nadiamiteva/mysqlserver-db"
            }
        }
        stage("Deliver API") {
            steps {
                // echo "===== REQUIRED: Will deliver the API to Docker Hub ====="
                sh "docker build ./db/docker -t nadiamiteva/mysqlserver-db"
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'DockerHub', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
				{
					sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
				}
                sh "docker push nadiamiteva/mysqlserver-db"
            }
        }
        stage("Release staging environment") {
            steps {
                // echo "===== REQUIRED: Will use Docker Compose to spin up a test environment ====="
                sh "docker-compose pull"
                sh "docker-compose up -d"
            }
        }
        stage("Automated acceptance test") {
            steps {
               //SeleniumGridSetUp
               sh "docker-compose -f selenium.yml up -d"
               sh "docker network create SE"
               sh "docker run -d --rm -p 4444:4444 --net=SE --name selenium-hub selenium/hub"
                 //sh "docker run -d --rm --net=SE -e HUB_HOST=selenium-hub --name slenium-node-firefox"
                 //sh "docker run -d --rm --net=SE -e HUB_HOST=selenium-hub --name slenium-node-chrome"
                 //sh "docker run -d --rm --net=SE --name app-test-container nadiamiteva/todoit_mysql-db"

               //Execute tests
               sleep time:15, unit:"SECONDS"
                 sh "slenium-side-runner-server http://localhost:4444/wd/hub -c 'browserName=firefox' --base-url http://app-host test/system/FunctionalTests.side"
                 sh "slenium-side-runner-server http://localhost:4444/wd/hub -c 'browserName=chrome' --base-url http://app-host test/system/FunctionalTests.side"
            }
        }
    }
    post {
        cleanup {
            echo "Cleaning the docker environment"
            sh script: "docker-compose -f slenium.yml down", returnStatus:true
            sh script:"docker stop selenium-hub", returnStatus:true
            sh script:"docker stop selenium-node-firefox", returnStatus:true
            sh script:"docker stop selenium-node-chrome", returnStatus:true
            sh script:"docker stop app-test-container", returnStatus:true
            sh script:"docker network remove SE", returnStatus:true
        }
    }
  }