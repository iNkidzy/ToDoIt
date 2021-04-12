pipeline {
    agent any
    triggers{
        pollSCM("H/5 * * * *")
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
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests  SeleniumHERE====="
            }
        }
    }
  }
}