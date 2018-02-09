<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Anime;
use AppBundle\Form\AnimeType;
use Beta\A;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class AnimeController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
        $repo = $this->getDoctrine()->getRepository(Anime::class);
        $animes = $repo->findAll();
        return $this->render(
            ":anime:index.html.twig",
            ["animes" => $animes]
        );
	}

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        $anime = new Anime();
        $form = $this->createForm(AnimeType::class, $anime);
        $form->handleRequest($request);
        if ($form->isSubmitted() && $form->isValid()) {
            $em = $this->getDoctrine()->getManager();
            $em->persist($anime);
            $em->flush();
            return $this->redirect("/");
        }
        return $this->render(
            ":anime:create.html.twig",
            ["anime" => $anime, "form" => $form->createView()]
        );
	}

    /**
     * @Route("/delete/{id}", name="delete")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function delete($id, Request $request)
    {
        $repo = $this->getDoctrine()->getRepository(Anime::class);
        $task = $repo->find($id);
        if ($task == null) {
            return $this->redirect("/");
        }
        $form = $this->createForm(AnimeType::class, $task);
        $form->handleRequest($request);
       if ($form->isSubmitted()) {
            $em = $this->getDoctrine()->getManager();
            $em->remove($task);
            $em->flush();
            return $this->redirect("/");
        }
        return $this->render(
            ":anime:delete.html.twig",
            ["anime" => $task, "form" => $form->createView()]
        );
    }
}
