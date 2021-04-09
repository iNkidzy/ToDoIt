pipeline {
    agent any
    triggers{
        pollSCM("0 */6 * * *")
    stages {
        stage("Build Web") {
            steps {
               echo "===== OPTIONAL: Will build the website (if needed) ====="
               // dotnet build src/WebRestbApi/WebRestApi.csproj
            }
        }
        stage("Build API") {
            steps {
                sh "dotnet build src/API/API.csproj"
               // echo "===== REQUIRED: Will build the API project ====="
            }
        }
        stage("Build database") {
            steps {
                echo "===== OPTIONAL: Will build the database (if using a state-based approach)Using Flyway so No ====="
            }
        }
        stage("Test API") {
            steps {
                echo "===== REQUIRED: Will execute unit tests of the API project ====="
            }
        }
        stage("Deliver Web") {
            steps {
                echo "===== REQUIRED: Will deliver the website to Docker Hub ====="
            }
        }
        stage("Deliver API") {
            steps {
                // echo "===== REQUIRED: Will deliver the API to Docker Hub ====="
                sh "docker build ./db/docker -t nadiamiteva/mysqlserver-db"
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'DockerHubID', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
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
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests ====="
            }
        }
    }
  }
}