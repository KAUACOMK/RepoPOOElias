Contribuinte c1 = new Contribuinte();
Holerite h1 = new Holerite();
Controller controller = new Controller();

Interface interface1 = new Interface();
Response response = new Response();

interface1.Input(c1);
controller.ControllerContribuinte(c1, h1);
response.Output(c1, h1);

